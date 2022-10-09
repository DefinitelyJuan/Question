using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using Proyecto348.dsScrapeTableAdapters;

namespace Proyecto348
{
    public partial class Resultados : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //searchNav.Visible = false;
            if(Session["searchResults"] != null)
            {
                searchNav.Visible = true;
                DataTable searchResults = (DataTable)Session["searchResults"];
                txtSearch.Text = (string)Session["SearchString"];
                foreach (DataRow result in searchResults.Rows)
                {
                    main.InnerHtml += $@"
    <div class=""card cardContainer mx-4"">
        <div class=""card-body"">
                <h3 class=""card-title"">{result["title"]}</h3>
                <a href=""{result["url"]}"" class=""resultLink card-subtitle"">{result["url"]}</a>                        
                <p class=""descriptionText card-text"">{result["description"]}</p>                        
        </div>
    </div>
";
                }
 
                

            }
            else
            {
                main.Attributes["class"] = "overflow-hidden h100 d-flex justify-content-center";
                main.InnerHtml += $@"<div class=""my-auto""><h1 class=""display-1"">Que problema...</h1><pre><p class=""pCustom"">Regrese a la página de <a class=""returnToMainLink"" href=""/frmSearch.aspx"">inicio</a></p></div>";
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ppBusquedaTableAdapter index = new ppBusquedaTableAdapter();
            string searchString = txtSearch.Text;
            DataTable searchResults = index.GetData(searchString);
            searchResults = searchResults.AsEnumerable()
                .GroupBy(x => x.Field<string>("title"))
                .Select(y => y.First())
                .CopyToDataTable();
            Session["searchResults"] = searchResults;
            if (Request.Cookies["recentSearches"] != null)
            {
                string recentSearches = Request.Cookies["recentSearches"].Value;
                List<string> recentSearchesList = recentSearches.Split(',').ToList();

                if (!recentSearchesList.Contains(searchString, StringComparer.InvariantCultureIgnoreCase))
                {
                    if (recentSearchesList.Count == 10)
                    {
                        recentSearchesList.RemoveAt(0);
                        recentSearchesList.Add(searchString);
                    }
                    else
                        recentSearchesList.Add(searchString);
                    recentSearches = "";
                    foreach (string search in recentSearchesList)
                    {
                        if (recentSearchesList.First() == search)
                            recentSearches += $"{search}";
                        else
                            recentSearches += $",{search}";
                    }

                    Response.Cookies["recentSearches"].Value = recentSearches;
                    Response.Cookies["recentSearches"].Expires = DateTime.Now.AddDays(1);
                }

            }
            else
            {
                Response.Cookies["recentSearches"].Value = $"{searchString}";
                Response.Cookies["recentSearches"].Expires = DateTime.Now.AddDays(1);

            }
            Response.Redirect("Resultados.aspx");
        }
    }
}