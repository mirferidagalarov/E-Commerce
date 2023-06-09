﻿using E_commerce_.NET5_.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace E_commerce_.NET5_.AppCode.Extensions
{
    static public partial class Extension
    {
        static public string GetCategoriesRaw(this List<Category> categories)
        {
            if (categories==null ||!categories.Any())
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='widget-body filter-items search-ul'>");
            foreach (var category in categories)
            {
                FillCategoriesRaw(category);
            }

            sb.Append("</ul>");
            return sb.ToString();    
            
            void FillCategoriesRaw(Category category)
            {
                sb.Append($"<li><a href='#'>{category.Name}</a>");
                if (category.Children !=null && category.Children.Any())
                {
                    sb.Append("<ul>");
                    foreach (var item in category.Children)
                    {
                        FillCategoriesRaw(item);

                    }

                    sb.Append("</ul>");
                }

                sb.Append("</li>");
            }
        }
        static public IEnumerable<Category> GetAllChildren(this Category category)
        {
            if (category.ParentId!=null)
            yield return category;

            if (category.Children !=null)
            {
                foreach (var item in category.Children.SelectMany(c => c.GetAllChildren()))
                {
                    yield return item;
                }

            }




        }

    }
}
