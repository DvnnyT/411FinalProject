using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class ShoppingListService
{
    private readonly IMongoCollection<ShoppingList> _shoppinglistCollection;
    public ShoppingListService(
        IOptions<ShoppingListDatabaseSettings> shoppingListDatabaseSettings)
    {
        var mongoClient = new MongoClient(
           shoppingListDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            shoppingListDatabaseSettings.Value.DatabaseName);

        _shoppinglistCollection = mongoDatabase.GetCollection<ShoppingList>(
            shoppingListDatabaseSettings.Value.ShoppingListCollectionName);

    }


    public async Task<List<ShoppingList>> GetAsync() =>
        await _shoppinglistCollection.Find(_ => true).ToListAsync();

    public async Task<ShoppingList?> GetAsync(string id) =>
        await _shoppinglistCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ShoppingList newShoppingList) =>
        await _shoppinglistCollection.InsertOneAsync(newShoppingList);

    public async Task UpdateAsync(string id, ShoppingList updatedShoppingList) =>
        await _shoppinglistCollection.ReplaceOneAsync(x => x.Id == id, updatedShoppingList);

    public async Task RemoveAsync(string id) =>
        await _shoppinglistCollection.DeleteOneAsync(x => x.Id == id);
}
