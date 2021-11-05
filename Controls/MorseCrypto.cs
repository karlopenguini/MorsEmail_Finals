using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorsEmail.Datastructures;


namespace MorsEmail.Models
{
    public class MorseCrypto
    {
        private TreeNode morseTree { get; set; }
        private Dictionary<char, string> morseHash { get;set; }

        public MorseCrypto()
        {
            morseTree = new TreeNode(' ',
                new TreeNode('E',
                    new TreeNode('I',
                        new TreeNode('S',
                            new TreeNode('H',
                                new TreeNode('5', null, null),
                                new TreeNode('4', null, null)
                                ),
                            new TreeNode('V', null,
                                new TreeNode('3', null, null)
                                )
                            ),

                        new TreeNode('U',
                            new TreeNode('F', null, null),
                            null)),
                    new TreeNode('A',
                        new TreeNode('R',
                            new TreeNode('L', null, null),
                            null),
                        new TreeNode('W',
                            new TreeNode('P', null, null),
                            new TreeNode('J', null,
                                new TreeNode('1', null, null)
                                )
                            )
                        )
                    ),

                new TreeNode('T',
                    new TreeNode('N',
                        new TreeNode('D',
                            new TreeNode('B',
                                new TreeNode('6', null, null),
                                new TreeNode('=', null, null)
                                ),
                            new TreeNode('X',
                                new TreeNode('/', null, null),
                                null)),
                        new TreeNode('K',
                            new TreeNode('C', null, null),
                            new TreeNode('Y', null, null)
                            )
                        ),
                    new TreeNode('M',
                        new TreeNode('G',
                            new TreeNode('Z',
                                new TreeNode('7', null, null),
                                null),
                            new TreeNode('Q', null, null)),
                        new TreeNode('O',
                            new TreeNode(' ',
                                new TreeNode('8', null, null),
                                null),
                            new TreeNode(' ',
                                new TreeNode('9', null, null),
                                new TreeNode('0', null, null)
                                )
                            )
                        )
                    )
                );

            morseHash = new Dictionary<char, string>
            {
                {'A', ".-"},
                {'B', "-..."},
                {'C', "-.-."},
                {'D', "-.."},
                {'E', "."},
                {'F', "..-."},
                {'G', "--."},
                {'H', "...."},
                {'I', ".."},
                {'J', ".---"},
                {'K', "-.-"},
                {'L', ".-.."},
                {'M', "--"},
                {'N', "-."},
                {'O', "---"},
                {'P', ".--."},
                {'Q', "--.-"},
                {'R', ".-."},
                {'S', "..."},
                {'T', "-"},
                {'U', "..-"},
                {'V', "...-"},
                {'W', ".--"},
                {'X', "-..-"},
                {'Y', "-.--"},
                {'Z', "--.."},
                {'0', "-----"},
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."},
                {'+', ".-.-."},
                {'=', "-...-"},
                {'/', "-..-."},
            };

        }


        private bool BFS(char c)
        {
            DynamicQueue<TreeNode> Q = new DynamicQueue<TreeNode>();

            List<char> explored = new List<char>();

            

            explored.Add(morseTree.letter);
            Q.Enqueue(morseTree);

            

            while (!Q.isEmpty())
            {
                TreeNode V = Q.Dequeue();
                
                if(V.letter == c)
                {
                    return true;
                }

                List<TreeNode> children = new List<TreeNode> { V.left, V.right };
                foreach(TreeNode child in children)
                {
                    if (child == null)
                    {
                        continue;
                    }

                    if (!explored.Contains(child.letter))
                    {
                        explored.Add(child.letter);
                        Q.Enqueue(child);
                    }
                }
            }

            return false;

        }


        public string Decrypt(string message)
        {


            List<string> morseArray = message.Split(' ').ToList();

            string decrypted = "";

            foreach(string morseChar in morseArray)
            {
                TreeNode curr = morseTree;
                
                foreach (char morseSymbol in morseChar)
                {
                    
                    if(morseSymbol == '\n')
                    {
                        decrypted += '\n';
                        continue;
                    }

                    if(morseSymbol == '.')
                    {
                        curr = curr.left;
                    }

                    else if(morseSymbol == '-')
                    {
                        curr = curr.right;
                    }

                    else if(morseSymbol == '/')
                    {
                        break;
                    }
                }
                decrypted += curr.letter;
            }
            return decrypted.Trim();
        }

        public string Encrypt(string message)
        {
            List<string> wordArray = message.Split(' ').ToList();

            string encrypted = "";

            foreach(string word in wordArray)
            {
                foreach(char letter in word)
                {
                    char _letter = char.Parse(letter.ToString().ToUpper());

                    if (_letter == '\n')
                    {
                        encrypted += "\n";
                        continue;
                    }

                    if (!BFS(_letter))
                    {
                        return null;
                    }
                    
                    encrypted += morseHash[_letter];
                    encrypted += " ";
                }
                encrypted += "/ ";
            }

            return encrypted.Trim();
        }

    } 
}
