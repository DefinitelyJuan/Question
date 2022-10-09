using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Proyecto348
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["searchResults"] != null)
            {
                DataTable searchResults = (DataTable)Session["searchResults"];
                foreach (DataRow result in searchResults.Rows)
                {
                    main.InnerHtml += $@"
<div class=""row resultContainer"">
    <div class=""card"">
        <div class=""card-body"">
                <h3 class=""card-title"">{result["title"]}</h3>
                <a href=""{result["url"]}"" class=""resultLink card-subtitle"">{result["url"]}</a>                        
                <p class=""descriptionText card-text"">{result["description"]}</p>                        
     </div>
        </div>
</div>";
                }
 
                

            }
            else
            {
                main.Attributes["class"] = "overflow-hidden h100 d-flex justify-content-center";
                main.InnerHtml += $@"<div class=""my-auto""><h1 class=""display-1"">Que problema...</h1><pre><p class=""pCustom"">Regrese a la página de <a class=""returnToMainLink"" href=""/frmSearch.aspx"">inicio</a></p></div>";
            }
        }
    }
}