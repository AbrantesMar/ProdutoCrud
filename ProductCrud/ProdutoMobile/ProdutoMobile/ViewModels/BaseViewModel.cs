using ProdutoMobile.Helpers;
using ProdutoMobile.Models;
using ProdutoMobile.Services;

using Xamarin.Forms;

namespace ProdutoMobile.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
		/// <summary>
		/// Get the azure service instance
		/// </summary>
		public IDataStore<ProdutoModel> DataStore => DependencyService.Get<IDataStore<ProdutoModel>>();

		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		string name = string.Empty;
		
		public string Nome
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}
	}
}

