using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace PretrageOsnovno
{
    class Graph
    {
        public Dictionary<string, Node> graph = null;

        public Graph(string[] linesNodes, string[] linesLinks, bool dodatni)
        {
            graph = new Dictionary<string, Node>();
            formGraph(linesNodes, linesLinks,dodatni);
        }

       
        private void formGraph(string[] linesNodes, string[] linesLinks,bool dodatni)
        {
            if (!dodatni)
            {//ukoliko nije dodatni
                char[] sep = { ':', ',' };
                foreach (String line in linesNodes)
                {                    
                    string[] lines = line.Split(sep);
                    Node node = new Node(lines[0], Double.Parse(lines[1]));
                    graph.Add(lines[0], node);

                }                
            }
            else
            {
                char[] sep = { ':', ',', ')', '(' };
                foreach (String line in linesNodes)
                {
                    string[] lines = line.Split(sep);
                    Point p = new Point(Double.Parse(lines[1]), //x i y kordinata
                                        Double.Parse(lines[2]));

                    Grad grad = new Grad(lines[0], //naziv
                                         p);//pozicija grada

                    graph.Add(lines[0], grad);

                }

            }

            char[] separator = { ':', ',' };
            foreach (String line in linesLinks)
            {
                string[] lines = line.Split(separator);
                if (graph.ContainsKey(lines[1]))
                {

                    Link link = new Link(graph[lines[1]], //startNode
                                         graph[lines[2]], //endNode
                                         lines[0],        //name  
                                         Double.Parse(lines[3])); //cost

                    graph[lines[1]].Links.Add(link);
                }
            }
            
        }

        #region ispis
        public void printGraph()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Node> kvp in graph)
            {
                foreach (Link link in kvp.Value.Links)
                {
                    Console.WriteLine(link.Name + ":" + link.StartNode + "," + link.EndNode + "," + link.Cost);
                }
            }
        }
        #endregion
    }
}
