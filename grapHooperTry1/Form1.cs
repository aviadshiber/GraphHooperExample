using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphHooperConnector;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;


namespace grapHooperTry1 {
    public partial class Form1 : Form {
        private string key = "PUT-API-KEY-HERE";
        private IGraphHooperConnector connector;
        public Form1() {
            InitializeComponent();
            connector = new GraphHooperConnectorImpl(key, "http://localhost:8989/");

        }

        private void Form1_Load(object sender, EventArgs e) {


        }

        private async void GetCorordinatesButton_Click(object sender, EventArgs e) {
            resultBox.Text = (await connector.getCoordiantesAsync(destBox.Text)).ToString();
        }



        private void copyButton1_Click(object sender, EventArgs e) {
            srcCoordinatesBox.Text = resultBox.Text;
        }

        private void copyButton2_Click(object sender, EventArgs e) {
            destCoordinatesBox.Text = resultBox.Text;
        }

        private async void RouteButton_Click(object sender, EventArgs e) {
            string[] cord1 = srcCoordinatesBox.Text.Split(',');
            string[] cord2 = destCoordinatesBox.Text.Split(',');
            double latCord1, longCord1, latCord2, longCord2;

            if (Double.TryParse(cord1[0], out latCord1) &&
                Double.TryParse(cord1[1], out longCord1) &&
                 Double.TryParse(cord2[0], out latCord2) &&
                 Double.TryParse(cord2[1], out longCord2)) {
                Coordinate src = new Coordinate(latCord1, longCord1);
                Coordinate dest = new Coordinate(latCord2, longCord2);
                RouteResponse result = await connector.getRouthAsync(src, dest, 30);
                foreach (var instuction in result?.Paths[0].Instructions) {
                    richTextBox1.AppendText($"time:{ instuction.Time} , next step:{instuction.Text}),sign:{instuction.Sign}\n");
                }

            } else {
                MessageBox.Show("Coordinates are not well formatted");
            }
        }

    }
}
