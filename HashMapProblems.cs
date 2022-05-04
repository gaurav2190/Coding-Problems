using System;
using System.Collections.Generic;
using System.Text;

namespace Coding_Problems
{
    public class HashMapProblems
    {
        public bool IsIsomorphic(string s, string t) {
            var map = new Dictionary<char, char>();
            
            if(s.Length != t.Length)
                return false;
            
            for(int i = 0; i < s.Length; i++)
            {
                if(!map.ContainsKey(s[i]))
                {
                    if(map.ContainsValue(t[i]))
                    {
                        return false;
                    }
                    map.Add(s[i], t[i]);
                }
                else if(map[s[i]] != t[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string[] FindRestaurant(string[] list1, string[] list2) {
            var table = new Dictionary<string,int>();
            for(int i = 0; i< list1.Length; i++)
            {
                table.Add(list1[i], i);
            }
            var output = new List<string>();
            int minIndex = int.MaxValue;
            for(int j = 0; j< list2.Length; j++)
            {
                if(table.ContainsKey(list2[j]))
                {
                    var indexSum = table[list2[j]]+j;

                    if(indexSum < minIndex)
                    {
                        minIndex = indexSum;
                        output.Clear();
                        output.Add(list2[j]);
                    }
                    else if (indexSum == minIndex)
                    {
                        output.Add(list2[j]);
                    }
                }            
            }      
                     
            return output.ToArray();
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k) {
            var table = new Dictionary<int, List<int>>();
        
            for(int i = 0; i<nums.Length; i++)
            {
                if(table.ContainsKey(nums[i]))
                {
                    foreach(var j in table[nums[i]])
                    {
                        if(Math.Abs((i-j)) <= k)
                        {
                            return true;
                        }
                    }
                    table[nums[i]].Add(i);
                }
                else
                {
                    table.Add(nums[i], new List<int>{i});
                }
            }

            return false;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs) {
            var output = new List<IList<string>>();
            var table = new Dictionary<string, List<string>>();
    
            foreach(var str in strs)
            {
                var s = new string(str);
                s = this.QuickSorting(s);
                if(!table.ContainsKey(s))
                {
                    table.Add(s, new List<string> { str });
                }
                else
                {
                    table[s].Add(str);
                }
            }

            foreach(var item in table)
            {
                output.Add(item.Value);
            }

            return output;
        }

        public string QuickSorting(string input)
        {
            var stringArray = input.ToCharArray();
            QuickSortString(0, stringArray.Length-1, ref stringArray);
            var result = new string(stringArray);

            return result;
        }

        public void QuickSortString(int l, int r,ref char[] input)
        {
            if(l < r)
            {
                var pivotIndex = this.PartitionString(l, r, ref input);
                QuickSortString(l, pivotIndex-1, ref input);
                QuickSortString(pivotIndex, r, ref input);
            }            
        }

        public int PartitionString(int l, int r, ref char[] s)
        {
            int i = l-1;
            var pivot = (int)s[r];

            for(int j = l; j<r; j++)
            {
                if((int)s[j] <= pivot)
                {
                    i++;
                    this.SwapChar(i, j, ref s);
                }
            }
            this.SwapChar(i+1, r, ref s);

            return i+1;
        }

        public void SwapChar(int i, int j, ref char[] s)
        {
            var temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }

        public bool IsValidSudoku(char[][] board) {
            var table = new Dictionary<char, List<string>>();
            int x,y;
            for(int i = 0; i< board.Length; i++)
            {
                for(int j = 0; j< board.Length; j++)
                {
                    if(board[i][j] == '.')
                        continue;
                    if(!table.ContainsKey(board[i][j]))
                    {
                        table.Add(board[i][j], new List<string> { i+","+j});
                    }
                    else
                    {
                        foreach(var str in table[board[i][j]])
                        {
                            var arr = str.Split(",");

                            if(i == int.Parse(arr[0]) || j == int.Parse(arr[1]))
                                return false;
                        }
                        x = y = -1;

                        x = (i >= 3) ? (i/3)*3 : 0;
                        y = (j >= 3) ? (j/3)*3 : 0;
                        
                        for( int k = x; k < x+3; k++)
                        {
                            for( int l = y; l < y+3; l++)
                            {
                                if(board[i][j] == board[k][l] && i != k && j != l)
                                {
                                    return false;
                                }
                            }
                        }

                        table[board[i][j]].Add(i+","+j);
                    }
                }
            }

            return true;
        }
    
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        var finalList = new List<TreeNode>();
            var table = new Dictionary<string, TreeNode>();
            var s = InOrderTraversal(root, ref table, "root");

            foreach(var item in table)
            {
                if(item.Value != null)
                    finalList.Add(item.Value);
            }
            return finalList;
    }
    
    public string InOrderTraversal(TreeNode node, ref Dictionary<string, TreeNode> table,string childPosition)
        {
            if(node == null)
                return "1"+childPosition;
            
            var s1 = new StringBuilder();

            s1.Append(InOrderTraversal(node.left, ref table, "L"));
            s1.Append(node.val);
            s1.Append(InOrderTraversal(node.right, ref table, "R"));

            var s = s1.ToString();
            if(!table.ContainsKey(s))
            {
                table.Add(s, null);
            }
            else
            {
                table[s] = node;
            }

            return s;
        }
    }
}