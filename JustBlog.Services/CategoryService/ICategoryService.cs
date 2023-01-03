using JustBlog.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Services.CategoryService
{
    public interface ICategoryService
    {
        IList<CategoryViewModel> GetAllCategories();
        IList<CategoryViewModel> GetPagedCategories(int page, int pageSize);
        int CountAllCategories();
        bool Delete(int id);
        bool Add(NewCategoryViewModel newCategory);
        bool Update(EditCategoryViewModel editCategory);
        EditCategoryViewModel GetEditCategoryById(int id);
        CategoryDetailsViewModel GetDetails(int id);
    }
}
