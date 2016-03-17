using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PretrageOsnovno
{
    class AStarSearch
    {
     
        public State Search(string startNodeName, string endNodeName,bool dodatni)
        {
            Node startNode = Program.instance.graph[startNodeName];
            Node endNode = Program.instance.graph[endNodeName];

            List<State> stanjaZaObradu = new List<State>();

            stanjaZaObradu.Add(new State(startNode));

            while (stanjaZaObradu.Count > 0)
            {
                State naObradi = stanjaZaObradu[0];
                stanjaZaObradu.Remove(naObradi);

                if (naObradi.Node.Name == endNode.Name)
                {
                    return naObradi;
                }
                else
                {
                    List<State> mogucaSledecaStanja = naObradi.children();                    
                    stanjaZaObradu.InsertRange(0, mogucaSledecaStanja);
                    sortiraj(stanjaZaObradu,endNode,dodatni);
                }
            }
            return null;
        }
        
       
        // metoda koja sortira listu u rastucem redosledu zbira cene i heuristike
        private void sortiraj(List<State> lista, Node endNode,bool dodatni)
        {
           
            if(lista.Count>0){
                //ukoliko ima sta da sortira
                //bubble sort
                bool flag = false;
                for (int i = 1; (i <= (lista.Count - 1))&&flag; i++)
			    {
                    for (int j = 0; j < (lista.Count - 1); j++)
                    {
                        if (dodatni)
                        {//ulazi u slucaju ako je dodatni zadatak
                            ((Grad)lista[j + 1].Node).izracunajHeuristic(((Grad)endNode).Position);
                            ((Grad)lista[j].Node).izracunajHeuristic(((Grad)endNode).Position);
                        }

                        double temp1 = lista[j + 1].Node.Heuristic + lista[j + 1].Cost;
                        double temp2 = lista[j].Node.Heuristic + lista[j].Cost;
                        if (temp1 > temp2)
                        {
                            var temp = lista[j];
                            lista[j] = lista[j + 1];
                            lista[j + 1] = temp;
                            flag = true;
                        }
                    }
                 
                 
			    }              
            
            }
           
        }

    }
}
