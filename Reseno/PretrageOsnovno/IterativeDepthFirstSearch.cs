using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PretrageOsnovno
{
    class IterativeDepthFirstSearch
    {
        private const int MaxLevel = 10000;
        private int currentLevel;

        
        public State Search(string startNodeName, string endNodeName)
        {

            Node startNode = Program.instance.graph[startNodeName];
            Node endNode = Program.instance.graph[endNodeName];

            List<State> stanjaZaObradu = new List<State>();

            stanjaZaObradu.Add(new State(startNode));
            currentLevel = 1;
            while (stanjaZaObradu.Count > 0 && currentLevel < MaxLevel)
            {
                State naObradi = stanjaZaObradu[0];
                stanjaZaObradu.Remove(naObradi);

                if (naObradi.Node.Name == endNode.Name)
                {
                    return naObradi;
                }
                else
                {
                    if (naObradi.Level <  currentLevel)
                    {
                        List<State> mogucaSledecaStanja = naObradi.children();
                        stanjaZaObradu.InsertRange(0, mogucaSledecaStanja);
                    }
                    else
                    {
                        if (stanjaZaObradu.Count == 0)
                        {
                            currentLevel++;
                            stanjaZaObradu.Add(new State(startNode));
                        }
                    }
                }
            }
            return null;
        }
    }
}
