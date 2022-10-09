using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto348.dsScrapeTableAdapters;
using System.Data;
namespace Proyecto348
{
    public partial class frmSearc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["RecentSearches"] != null)
            {
                string recentSearches = Request.Cookies["RecentSearches"].Value;
                List<string> searchesList = recentSearches.Split(',').ToList();
                recentSearches = "";
                foreach (string search in searchesList)
                {
                    recentSearches += search + "<br/>";
                }
                string script = @"
                    
                    $(document).ready(function() {
                     $('#txtSearchString').popover({ trigger: 'focus', title: 'Busquedas Recientes', content:'" + recentSearches + "',html: true }) })";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "key", script, true);




            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ppBusquedaTableAdapter index = new ppBusquedaTableAdapter();
            string searchString = txtSearchString.Text;
            DataTable searchResults = index.GetData(searchString);
            searchResults = searchResults.AsEnumerable()
                .GroupBy(x => x.Field<string>("title"))
                .Select(y => y.First())
                .CopyToDataTable();
            Session["searchResults"] = searchResults;
            if(Request.Cookies["recentSearches"] != null)
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
                        if(recentSearchesList.First() == search)
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
            Session["SearchString"] =searchString;
            Response.Redirect("Resultados.aspx");
        }
    }
}