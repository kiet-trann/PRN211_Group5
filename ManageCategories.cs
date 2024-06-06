using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCategoriesApp1
{
	public sealed class ManageCategories
	{
		//Using Singleton Pattern
		private static ManageCategories instance = null;
		private static readonly object instanceLock = new object();
		private ManageCategories() { }
		public static ManageCategories Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new ManageCategories();
					}
					return instance;
				}
			}
		}
		public List<Category> GetCategories()
		{
			List<Category> categories;
			try
			{
				using MyStock myStock = new MyStock();
				categories = myStock.Categories.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return categories;
		}// end GetCategories
		 //----------------------------------------------------------------------------------
		public void InsertCategory(Category category)
		{
			try
			{
				using MyStock stock = new MyStock();
				stock.Categories.Add(category);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}//end InsertCategory
		 //------------------------------------------------------------------------------------
		public void DeleteCategory(Category category)
		{
			try
			{
				using MyStock stock = new MyStock();
				//Find Category by CategoryID
				var cate = stock.Categories.SingleOrDefault(c => c.CategoryID == category.CategoryID);
				stock.Categories.Remove(cate);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}// end DeleteCAtegory
		//------------------------------------------------------------------------------------------------
		public void UpdateCategory(Category category)
		{
			try
			{
				using MyStock stock = new MyStock();
				stock.Categories.Update(category);
				stock.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}//end UpdateCategory
	}
}
