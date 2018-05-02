using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteStackBuilders;

public partial class _Default : Page
{
    int counter = 0;
    DataTable dtSongsTable;
    Reproduce obj = new Reproduce();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //load combos
            loadComboBox();
            createTemporalTable();//canciones
            Session["TBLSONGS"] = dtSongsTable;
        }
    }

    private void createTemporalTable()
    {
        obj = new Reproduce();
        dtSongsTable = new DataTable();
        DataColumn dcIdSecuencial = new DataColumn("SECUENCIAL", Type.GetType("System.Int32"));
        DataColumn dcNumSong = new DataColumn("NUMSONG", Type.GetType("System.Int32"));
        DataColumn dcSoundValue = new DataColumn("SOUNDVALUE", Type.GetType("System.String"));
        DataColumn dcSoundText = new DataColumn("SOUNDTEXT", Type.GetType("System.String"));

        dtSongsTable.Columns.AddRange(new DataColumn[] { dcIdSecuencial, dcNumSong, dcSoundValue, dcSoundText});
                
        int numCancion = 1;
        counter = 0;
        obj.createRows(ref dtSongsTable, ref counter, numCancion);

        numCancion = 2;
        obj.createRows(ref dtSongsTable, ref  counter, numCancion);

        numCancion = 3;
        obj.createRows(ref dtSongsTable, ref counter, numCancion);

      
    }

  

    private void loadComboBox()
    {
        ddlFrog.Items.Add(new ListItem("[Select One]", "noneF"));
        ddlFrog.Items.Add(new ListItem("brr", "brr"));
        ddlFrog.Items.Add(new ListItem("birip", "birip"));
        ddlFrog.Items.Add(new ListItem("brrah", "brrah"));
        ddlFrog.Items.Add(new ListItem("croac", "croac"));
        

        ddlDragonFly.Items.Add(new ListItem("[Select One]", "noneD"));
        ddlDragonFly.Items.Add(new ListItem("fiu", "fiu"));
        ddlDragonFly.Items.Add(new ListItem("plop", "plop"));
        ddlDragonFly.Items.Add(new ListItem("pep", "pep"));

        ddlCriket.Items.Add(new ListItem("[Select One]", "noneC"));
        ddlCriket.Items.Add(new ListItem("cric-cric", "criccric"));
        ddlCriket.Items.Add(new ListItem("trri-trri", "trritrri"));
        ddlCriket.Items.Add(new ListItem("bri-bri", "bribri"));
    }

    protected void ddlFrog_SelectedIndexChanged(object sender, EventArgs e)
    {
        //leave just one sound selected
        ddlCriket.DataValueField = "noneC";
        ddlCriket.SelectedIndex = 0;
        ddlDragonFly.DataValueField = "noneD";
        ddlDragonFly.SelectedIndex = 0;
        lblMensaje.Text = "";

    }

    protected void ddlDragonFly_SelectedIndexChanged(object sender, EventArgs e)
    {
        //leave just one sound selected
        ddlFrog.DataValueField = "noneF";
        ddlFrog.SelectedIndex = 0;
        ddlCriket.DataValueField = "noneC";
        ddlCriket.SelectedIndex = 0;
        lblMensaje.Text = "";
    }

    protected void ddlCriket_SelectedIndexChanged(object sender, EventArgs e)
    {
        //leave just one sound selected
        ddlFrog.DataValueField = "noneF";
        ddlFrog.SelectedIndex = 0;
        ddlDragonFly.DataValueField = "noneD";
        ddlDragonFly.SelectedIndex = 0;
        lblMensaje.Text = "";
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        obj = new Reproduce();
        dtSongsTable = ((DataTable)Session["TBLSONGS"]).Copy();
        //look for the sound among the three songs
        string value = "";       

        if(ddlFrog.SelectedIndex == 0 && ddlDragonFly.SelectedIndex == 0 && ddlCriket.SelectedIndex == 0)
        {
            lblMensaje.Text = "You have selected no sound!!";
        }
        else
        {      
            if (ddlFrog.SelectedIndex > 0)
            {
                value = ddlFrog.SelectedValue;             
            }
            if (ddlDragonFly.SelectedIndex > 0)
            {
                value = ddlDragonFly.SelectedValue;
            }
            if (ddlCriket.SelectedIndex > 0)
            {
                value = ddlCriket.SelectedValue;
            }

            lblMensaje.Text= obj.captureMessage(value, dtSongsTable);        
        
        }
    }

}