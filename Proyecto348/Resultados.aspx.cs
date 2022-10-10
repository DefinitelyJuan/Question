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
            searchNav.Visible = false;
            if (!IsPostBack)
            {
                if (Session["SearchType"] != null)
                {
                    string searchType = (string)Session["SearchType"];
                    searchNav.Visible = true;
                    txtSearch.Text = (string)Session["SearchString"];
                    if (searchType == "Todo")
                    {
                        main.Attributes["class"] = "main";
                        if (Session["searchResults"] != null)
                        {
                            DataTable searchResults = (DataTable)Session["searchResults"];
                            if (searchResults.Rows.Count > 0)
                            {
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
                                main.InnerHtml += $@"<div class=""my-auto""><h1 class=""display-1"">Sin resultados...</h1><pre><p class=""pCustom"">Regrese a la página de <a class=""returnToMainLink"" href=""/frmSearch.aspx"">inicio</a> o pruebe con <a class=""returnToMainLink"" href=""javascript: __doPostBack('lbImage', '')"">Imagenes</a></p></div>";
                            }




                        }
                    }
                    else
                    {
                       
                    }
                }
                else
                {
                    main.Attributes["class"] = "overflow-hidden h100 d-flex justify-content-center";
                    main.InnerHtml += $@"<div class=""my-auto""><h1 class=""display-1"">Que problema...</h1><pre><p class=""pCustom"">Regrese a la página de <a class=""returnToMainLink"" href=""/frmSearch.aspx"">inicio</a></p></div>";
                }
            }
            if (Session["SearchType"] != null)
            {
                string searchType = (string)Session["SearchType"];

                if (searchType == "Img" && !IsPostBack){
                    txtSearch.Text = (string)Session["SearchString"];
                    main.Attributes["class"] = "main";
                    ppImgBusquedaTableAdapter index = new ppImgBusquedaTableAdapter();
                    string searchString = (string)Session["SearchString"];
                    DataTable searchResults = index.GetData(searchString);
                    searchResults = searchResults.AsEnumerable()
                        .GroupBy(x => x.Field<string>("src"))
                        .Select(y => y.First())
                        .CopyToDataTable();
                    foreach (DataRow result in searchResults.Rows)
                    {
                        main.InnerHtml += $@"
                    <div class=""card cardContainer mx-4"">
                        <img src={result["src"]} class = card-img-top/>
                        <div class=""card-body"">
                                <p class="" descriptionText card-text"">{result["alt"]}</p>               
                        </div>
                    </div>
                ";
                    }
                    lbAll.CssClass = "btn btn-outline-primary btnBuscarInactive";
                    lbImage.CssClass = "btn btn-outline-primary btnBuscarActive";
                }
            }
            



            }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ppBusquedaTableAdapter index = new ppBusquedaTableAdapter();
            string searchString = txtSearch.Text;
            DataTable searchResults = index.GetData(searchString);
            if (searchResults != null)
            {
                if (searchResults.Rows.Count > 0)
                {
                    searchResults = searchResults.AsEnumerable()
                        .GroupBy(x => x.Field<string>("title"))
                        .Select(y => y.First())
                        .CopyToDataTable();
                }
                Session["searchResults"] = searchResults;

            }

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
            Session["SearchType"] = "Todo";
            Session["SearchString"] = txtSearch.Text;

            Response.Redirect("Resultados.aspx");
        }

        protected void lbAll_Click(object sender, EventArgs e)
        {
            Session["SearchType"] = "Todo";
            Session["SearchString"] = txtSearch.Text;
            Response.Redirect("Resultados.aspx");
        }

        protected void lbImage_Click(object sender, EventArgs e)
        {
            Session["SearchType"] = "Img";
            Session["SearchString"] = txtSearch.Text;
            Response.Redirect("Resultados.aspx");
        }
    }
}