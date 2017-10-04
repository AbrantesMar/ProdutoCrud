using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProdutoMobile.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(ProdutoMobile.Services.MockDataStore))]
namespace ProdutoMobile.Services
{
	public class MockDataStore : IDataStore<ProdutoModel>
	{
		bool isInitialized;
		List<ProdutoModel> items;

		public async Task<bool> AddItemAsync(ProdutoModel item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(ProdutoModel item)
		{
			await InitializeAsync();

			var _item = items.Where((ProdutoModel arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(ProdutoModel item)
		{
			await InitializeAsync();

			var _item = items.Where((ProdutoModel arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<ProdutoModel> GetItemAsync(long id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<ProdutoModel>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			items = new List<ProdutoModel>();
            var _items = new List<ProdutoModel>
            {
                new ProdutoModel { Id = 1, Nome = "Buy some cat food", Categoria = eCategoria.BEBIDAS }
            };

            foreach (ProdutoModel item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
