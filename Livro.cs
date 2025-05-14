using System.Collections.Generic;

public class Livro
{
    private Dictionary<string, string> livros;

    public Livro()
    {
        livros = new Dictionary<string, string>
        {
            { "Gênesis", "Gênesis" },
            { "Êxodo", "Êxodo" },
            { "Levítico", "Levítico" },
            { "Números", "Números" },
            { "Deuteronômio", "Deuteronômio" },
            { "Josué", "Josué" },
            { "Juízes", "Juízes" },
            { "Rute", "Rute" },
            { "1 Samuel", "1 Samuel" },
            { "2 Samuel", "2 Samuel" },
            { "1 Reis", "1 Reis" },
            { "2 Reis", "2 Reis" },
            { "1 Crônicas", "1 Crônicas" },
            { "2 Crônicas", "2 Crônicas" },
            { "Esdras", "Esdras" },
            { "Neemias", "Neemias" },
            { "Ester", "Ester" },
            { "Jó", "Jó" },
            { "Salmos", "Salmos" },
            { "Provérbios", "Provérbios" },
            { "Eclesiastes", "Eclesiastes" },
            { "Cânticos", "Cânticos" },
            { "Isaías", "Isaías" },
            { "Jeremias", "Jeremias" },
            { "Lamentações", "Lamentações" },
            { "Ezequiel", "Ezequiel" },
            { "Daniel", "Daniel" },
            { "Oséias", "Oséias" },
            { "Joel", "Joel" },
            { "Amós", "Amós" },
            { "Obadias", "Obadias" },
            { "Jonas", "Jonas" },
            { "Miquéias", "Miquéias" },
            { "Naum", "Naum" },
            { "Habacuque", "Habacuque" },
            { "Sofonias", "Sofonias" },
            { "Ageu", "Ageu" },
            { "Zacarias", "Zacarias" },
            { "Malaquias", "Malaquias" },
            { "Mateus", "Mateus" },
            { "Marcos", "Marcos" },
            { "Lucas", "Lucas" },
            { "João", "João" },
            { "Atos", "Atos" },
            { "Romanos", "Romanos" },
            { "1 Coríntios", "1 Coríntios" },
            { "2 Coríntios", "2 Coríntios" },
            { "Gálatas", "Gálatas" },
            { "Efésios", "Efésios" },
            { "Filipenses", "Filipenses" },
            { "Colossenses", "Colossenses" },
            { "1 Tessalonicenses", "1 Tessalonicenses" },
            { "2 Tessalonicenses", "2 Tessalonicenses" },
            { "1 Timóteo", "1 Timóteo" },
            { "2 Timóteo", "2 Timóteo" },
            { "Tito", "Tito" },
            { "Filemom", "Filemom" },
            { "Hebreus", "Hebreus" },
            { "Tiago", "Tiago" },
            { "1 Pedro", "1 Pedro" },
            { "2 Pedro", "2 Pedro" },
            { "1 João", "1 João" },
            { "2 João", "2 João" },
            { "3 João", "3 João" },
            { "Judas", "Judas" },
            { "Apocalipse", "Apocalipse" }
        };


    }

    public Dictionary<string, string> ObterLivros()
    {
        return livros;
    }

    public bool ContemLivro(string nomeLivro)
    {
        return livros.ContainsKey(nomeLivro);
    }

    public int ObterNumeroDeCapitulos(string nomeLivro)
    {
        int totalCapitulos = 0;

        switch (nomeLivro)
        {
            case "Gênesis":
                totalCapitulos = 50;
                break;
            case "Êxodo":
                totalCapitulos = 40;
                break;
            case "Levítico":
                totalCapitulos = 27;
                break;
            case "Números":
                totalCapitulos = 36;
                break;
            case "Deuteronômio":
                totalCapitulos = 34;
                break;
            case "Josué":
                totalCapitulos = 24;
                break;
            case "Juízes":
                totalCapitulos = 21;
                break;
            case "Rute":
                totalCapitulos = 4;
                break;
            case "1 Samuel":
                totalCapitulos = 31;
                break;
            case "2 Samuel":
                totalCapitulos = 24;
                break;
            case "1 Reis":
                totalCapitulos = 22;
                break;
            case "2 Reis":
                totalCapitulos = 25;
                break;
            case "1 Crônicas":
                totalCapitulos = 29;
                break;
            case "2 Crônicas":
                totalCapitulos = 36;
                break;
            case "Esdras":
                totalCapitulos = 10;
                break;
            case "Neemias":
                totalCapitulos = 13;
                break;
            case "Ester":
                totalCapitulos = 10;
                break;
            case "Jó":
                totalCapitulos = 42;
                break;
            case "Salmos":
                totalCapitulos = 150;
                break;
            case "Provérbios":
                totalCapitulos = 31;
                break;
            case "Eclesiastes":
                totalCapitulos = 12;
                break;
            case "Cânticos":
                totalCapitulos = 8;
                break;
            case "Isaías":
                totalCapitulos = 66;
                break;
            case "Jeremias":
                totalCapitulos = 52;
                break;
            case "Lamentações":
                totalCapitulos = 5;
                break;
            case "Ezequiel":
                totalCapitulos = 48;
                break;
            case "Daniel":
                totalCapitulos = 12;
                break;
            case "Oséias":
                totalCapitulos = 14;
                break;
            case "Joel":
                totalCapitulos = 3;
                break;
            case "Amós":
                totalCapitulos = 9;
                break;
            case "Obadias":
                totalCapitulos = 1;
                break;
            case "Jonas":
                totalCapitulos = 4;
                break;
            case "Miquéias":
                totalCapitulos = 7;
                break;
            case "Naum":
                totalCapitulos = 3;
                break;
            case "Habacuque":
                totalCapitulos = 3;
                break;
            case "Sofonias":
                totalCapitulos = 3;
                break;
            case "Ageu":
                totalCapitulos = 2;
                break;
            case "Zacarias":
                totalCapitulos = 14;
                break;
            case "Malaquias":
                totalCapitulos = 4;
                break;
            case "Mateus":
                totalCapitulos = 28;
                break;
            case "Marcos":
                totalCapitulos = 16;
                break;
            case "Lucas":
                totalCapitulos = 24;
                break;
            case "João":
                totalCapitulos = 21;
                break;
            case "Atos":
                totalCapitulos = 28;
                break;
            case "Romanos":
                totalCapitulos = 16;
                break;
            case "1 Coríntios":
                totalCapitulos = 16;
                break;
            case "2 Coríntios":
                totalCapitulos = 13;
                break;
            case "Gálatas":
                totalCapitulos = 6;
                break;
            case "Efésios":
                totalCapitulos = 6;
                break;
            case "Filipenses":
                totalCapitulos = 4;
                break;
            case "Colossenses":
                totalCapitulos = 4;
                break;
            case "1 Tessalonicenses":
                totalCapitulos = 5;
                break;
            case "2 Tessalonicenses":
                totalCapitulos = 3;
                break;
            case "1 Timóteo":
                totalCapitulos = 6;
                break;
            case "2 Timóteo":
                totalCapitulos = 4;
                break;
            case "Tito":
                totalCapitulos = 3;
                break;
            case "Filemon":
                totalCapitulos = 1;
                break;
            case "Hebreus":
                totalCapitulos = 13;
                break;
            case "Tiago":
                totalCapitulos = 5;
                break;
            case "1 Pedro":
                totalCapitulos = 5;
                break;
            case "2 Pedro":
                totalCapitulos = 3;
                break;
            case "1 João":
                totalCapitulos = 5;
                break;
            case "2 João":
                totalCapitulos = 1;
                break;
            case "3 João":
                totalCapitulos = 1;
                break;
            case "Judas":
                totalCapitulos = 1;
                break;
            case "Apocalipse":
                totalCapitulos = 22;
                break;
            default:
                totalCapitulos = 0;
                break;
        }

        return totalCapitulos;
    }
}
