using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithm
{
    /// <summary>
    /// 算法帮助类
    /// </summary>
    public static class Helper
    {
        #region 不借用第三个变量,怎么把a,b的值互换
        public static void Exchange(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        #endregion

        #region 1-2+3-4+……+m
        public static int Sum(int num)
        {
            if (num <= 0)
                throw new Exception("参数不合法");
            int Sum = 0;
            for (int i = 0; i < num + 1; i++)
            {
                if ((i % 2) == 1)
                    Sum += i;
                else
                    Sum = Sum - i;
            }
            return Sum;
        }

        public static int Sum2(int num)
        {
            if (num <= 0)
                throw new Exception("参数不合法");
            int Sum = (num + 1) / 2;
            if ((num % 2) == 0)
                Sum = -Sum;
            return Sum;
        }
        #endregion

        #region 1、1、2、3、5、8、13、21、34......  求第30位数是多少
        public static int Foo(int i)
        {
            if (i <= 0)
                return 0;
            else if (i > 0 && i <= 2)
                return 1;
            else
                return Foo(i - 1) + Foo(i - 2);
        }
        #endregion

        #region 求连续子数组的最大和
        public static int GetMaxAddOfArray(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                throw new Exception("参数不合法");
            int sz = arr.Length;
            int result = arr[0];
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    int temp = 0;
                    for (int k = i; k <= j; k++)
                        temp += arr[k];

                    if (temp > result)
                        result = temp;
                }
            }
            return result;
        }
        public static int GetMaxAddOfArray2(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                throw new Exception("参数不合法");
            int sz = arr.Length;
            int result = arr[0];
            for (int i = 0; i < sz; i++)
            {
                int temp = 0;
                for (int j = i; j < sz; j++)
                {
                    temp += arr[j];
                    if (temp > result)
                        result = temp;
                }
            }
            return result;
        }
        public static int GetMaxAddOfArray3(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                throw new Exception("参数不合法");
            int sz = arr.Length;
            int Sum = arr[0];   //临时最大值
            int MAX = arr[0];   //比较之后的最大值
            for (int i = 1; i < sz; i++)
            {
                Sum = Sum + arr[i] > arr[i] ? Sum + arr[i] : arr[i];   //状态方程
                if (Sum >= MAX)
                    MAX = Sum;
            }
            return MAX;
        }
        public static int GetMaxAddOfArray4(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                throw new Exception("参数不合法");
            int sz = arr.Length;
            int sum = arr[0];//临时最大值
            int MAX = arr[0];//比较之后的最大值
            for (int i = 1; i < sz; i++)
            {
                if (sum < 0)
                    sum = arr[i];
                else
                    sum += arr[i];

                if (sum > MAX)
                    MAX = sum;
            }
            return MAX;
        }
        #endregion

        #region 求连续子数组的最大和 且 返回子数组
        public static Tuple<int, Array> GetMaxAddAndArray(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                throw new Exception("参数不合法");
            int sz = arr.Length;
            int result = arr[0];
            int start = 0;
            int end = 0;
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    int temp = 0;
                    for (int k = i; k <= j; k++)
                        temp += arr[k];

                    if (temp > result)
                    {
                        start = i;
                        end = j;
                        result = temp;
                    }
                }
            }

            List<int> list = new List<int>();
            for (int i = start; i <= end; i++)
            {
                list.Add(arr[i]);
            }
            Tuple<int, Array> tuple = new Tuple<int, Array>(result, list.ToArray());
            return tuple;
        }
        public static Tuple<int, Array> GetMaxAddAndArray2(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                throw new Exception("参数不合法");
            int sz = arr.Length;
            int result = arr[0];
            int start = 0;
            int end = 0;
            for (int i = 0; i < sz; i++)
            {
                int temp = 0;
                for (int j = i; j < sz; j++)
                {
                    temp += arr[j];
                    if (temp > result)
                    {
                        start = i;
                        end = j;
                        result = temp;
                    }
                }
            }
            List<int> list = new List<int>();
            for (int i = start; i <= end; i++)
            {
                list.Add(arr[i]);
            }
            Tuple<int, Array> tuple = new Tuple<int, Array>(result, list.ToArray());
            return tuple;
        }
        #endregion

        #region 数组反转置顶开始位置和结束位置
        public static void Reverse(int[] arry, int begin, int end)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            if (begin < 0 || end < 0)
                throw new Exception("开始或者结束位置所以没有正确设置");
            if (end > arry.Length)
                throw new Exception("结束位置超出数组长度");
            while (begin < end)
            {
                int temp = arry[end];
                arry[end] = arry[begin];
                arry[begin] = temp;
                begin++;
                end--;
            }

        }

        public static void Reverse<T>(T[] arry, int begin, int end)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            if (begin < 0 || end < 0)
                throw new Exception("开始或者结束位置所以没有正确设置");
            if (end > arry.Length)
                throw new Exception("结束位置超出数组长度");
            while (begin < end)
            {
                T temp = arry[end];
                arry[end] = arry[begin];
                arry[begin] = temp;
                begin++;
                end--;
            }

        }
        #endregion

        #region 删除集合给定元素
        public static void deleteForm(ArrayList aList, object key)
        {
            if (null == aList)
                throw new Exception("aList不能为null");
            //if (aList.Contains(key)) aList.Remove(key);//删除单个
            while (aList.Contains(key))//删除所有
                aList.Remove(key);
        }

        public static void deleteForm<T>(IList<T> aList, T key, bool deleteAll = false)
        {
            if (null == aList)
                throw new Exception("aList不能为null");

            if (deleteAll)
            {
                while (aList.Contains(key))//删除所有
                    aList.Remove(key);
            }
            else
            {
                if (aList.Contains(key)) aList.Remove(key);//删除单个
            }

        }
        #endregion

        #region 数组合并去重
        public static int[] CombinedArray(int[] a, int[] b)
        {
            if (null == a || null == b)
                throw new Exception("arry不能为null");
            var _list = a.ToList();
            foreach (var item in b)
            {
                if (!_list.Contains(item))
                    _list.Add(item);
            }
            return _list.ToArray();
        }
        public static T[] CombinedArray<T>(T[] a, T[] b)
        {
            if (null == a || null == b)
                throw new Exception("arry不能为null");
            var _list = a.ToList();
            foreach (var item in b)
            {
                if (!_list.Contains(item))
                    _list.Add(item);
            }
            return _list.ToArray();
        }
        public static T[] CombinedArrayNew<T>(T[] a, T[] b)
        {
            if (null == a || null == b)
                throw new Exception("arry不能为null");
            List<T> _list = new List<T>();
            foreach (var item in a)
            {
                if (!_list.Contains(item))
                    _list.Add(item);
            }
            foreach (var item in b)
            {
                if (!_list.Contains(item))
                    _list.Add(item);
            }
            return _list.ToArray();
        }
        #endregion

        #region 两个数组  [n] [m]  n>m  第一个数组的数字无序排列 第二个数组为空 取出第一个数组的最小值 放到第二个数组中第一个位置, 依次类推. 不能改变A数组，不能对之进行排序，也不可以倒到别的数组中。

        /// <summary>
        /// 两个数组  [n] [m]  n>m  第一个数组的数字无序排列 第二个数组为空 取出第一个数组的最小值
        /// 放到第二个数组中第一个位置, 依次类推. 不能改变A数组，不能对之进行排序，也不可以倒到别的数组中。
        /// </summary>
        public static void GetArr(int[] n, int[] m)//最小放第一
        {
            if (n.Length <= m.Length)
                throw new Exception("参数不合法");
            int intTmp = n[0];
            int intMaxNum;
            for (int i = 0; i < n.Length; i++)
                intTmp = n[i] > intTmp ? n[i] : intTmp;
            intMaxNum = intTmp;
            for (int j = 0; j < m.Length; j++)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (j == 0)
                        intTmp = n[i] < intTmp ? n[i] : intTmp;
                    else
                    {
                        if (n[i] > m[j - 1])
                            intTmp = n[i] < intTmp ? n[i] : intTmp;
                    }
                }
                m[j] = intTmp;
                intTmp = intMaxNum;
            }
        }
        public static void GetArr2(int[] n, int[] m)//最大放第一
        {
            if (n.Length <= m.Length)
                throw new Exception("参数不合法");
            int intTmp = n[0];
            int intMinNum;
            for (int i = 0; i < n.Length; i++)
                intTmp = n[i] < intTmp ? n[i] : intTmp;
            intMinNum = intTmp;
            for (int j = 0; j < m.Length; j++)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (j == 0)
                        intTmp = n[i] > intTmp ? n[i] : intTmp;
                    else
                    {
                        if (n[i] < m[j - 1])
                            intTmp = n[i] > intTmp ? n[i] : intTmp;
                    }
                }
                m[j] = intTmp;
                intTmp = intMinNum;
            }
        }

        public static void GetArrNew(int[] n, int[] m)//最小放最后
        {
            if (n.Length <= m.Length)
                throw new Exception("参数不合法");
            int intTmp = n[0];
            int intMaxNum;
            for (int i = 0; i < n.Length; i++)
                intTmp = n[i] > intTmp ? n[i] : intTmp;
            intMaxNum = intTmp;
            for (int j = m.Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (j == m.Length - 1)
                        intTmp = n[i] < intTmp ? n[i] : intTmp;
                    else
                    {
                        if (n[i] > m[j + 1])
                            intTmp = n[i] < intTmp ? n[i] : intTmp;
                    }
                }
                m[j] = intTmp;
                intTmp = intMaxNum;
            }
        }

        public static void GetArr2New(int[] n, int[] m)//最大放最后
        {
            if (n.Length <= m.Length)
                throw new Exception("参数不合法");
            int intTmp = n[0];
            int intMinNum;
            for (int i = 0; i < n.Length; i++)
                intTmp = n[i] < intTmp ? n[i] : intTmp;
            intMinNum = intTmp;
            for (int j = m.Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (j == m.Length - 1)
                        intTmp = n[i] > intTmp ? n[i] : intTmp;
                    else
                    {
                        if (n[i] < m[j + 1])
                            intTmp = n[i] > intTmp ? n[i] : intTmp;
                    }
                }
                m[j] = intTmp;
                intTmp = intMinNum;
            }
        }
        #endregion

        #region 产生一个int数组，长度为100，并向其中随机插入1-100，并且不能重复。
        public static int[] CreateArr(int count = 1)
        {
            if (count < 0)
                throw new Exception("参数不合法");
            int[] intArr = new int[count];
            List<int> myList = new List<int>();
            Random rnd = new Random();
            while (myList.Count < count)
            {
                int num = rnd.Next(1, count + 1);
                if (!myList.Contains(num))
                    myList.Add(num);
            }
            return myList.ToArray();
        }
        #endregion

        #region 字符串处理

        /// <summary>
        /// 字符串倒序输出 123456 输出654321
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Reverse(string str = "123456")
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("参数不合法");
            StringBuilder sb = new StringBuilder(str.Length);
            for (int index = str.Length - 1; index >= 0; index--)
                sb.Append(str[index]);
            return sb.ToString();
        }

        /// <summary>
        /// 请将字符串"I am a student"按单词逆序输出如"student a am I"
        /// </summary>
        /// <param name="str">字符串参数</param>
        /// <param name="str">分割字符串</param>
        /// <returns></returns>
        public static string ReverseWord(string str = "I am a student", string split = " ")
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("参数不合法");
            StringBuilder sb = new StringBuilder(str.Length);
            string[] n = str.Split(split);
            for (int i = n.Length - 1; i >= 0; i--)
            {
                sb.Append(n[i]);
                if (i != 0)
                    sb.Append(" ");
            }
            return sb.ToString();
        }

        static string Reverse0(string str = "I am a student")
        {
            string strReturn = "";
            foreach (char c in str)
            {
                strReturn = c + strReturn;
            }
            Console.Write(strReturn);
            return strReturn;
        }

        public static void Reverse1(string S = "I am a student")
        {
            Console.Write(S.Reverse());
        }

        public static void Reverse2(string S = "I am a student")
        {
            for (int i = S.Length - 1; i >= 0; i--)
            {
                Console.Write(S.Substring(i, 1));
            }
        }
        #endregion

        #region 一口井深7米,一直蜗牛往上爬,白天爬3米,晚上掉2米。几天爬出去
        public static int Out(int high = 7, int add = 3, int reduce = 2)
        {
            int result = 1;
            while (high > 3)
            {
                result++;
                high = high - add + reduce;
            }
            return result;
        }

        #endregion

        #region 排序

        /// <summary>
        /// 冒泡排序 0升序 1降序
        /// </summary>
        /// <param name="arry">数组</param>
        /// <param name="isAsc">排序方式</param>
        public static void SoftByBubbleOld(int[] arry, bool isAsc = true)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            int temp = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = i + 1; j < arry.Length; j++)
                {
                    if (arry[i] > arry[j] == isAsc)
                    {
                        temp = arry[i];
                        arry[i] = arry[j];
                        arry[j] = temp;
                    }
                }

            }
        }

        /// <summary>
        /// 冒泡排序 0升序 1降序
        /// </summary>
        /// <param name="arry">数组</param>
        /// <param name="isAsc">排序方式</param>
        public static void SoftByBubble(int[] arry, bool isAsc = true)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            int temp = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = 0; j < arry.Length - 1 - i; j++)
                {
                    if (arry[j] > arry[j + 1] == isAsc)
                    {
                        temp = arry[j];
                        arry[j] = arry[j + 1];
                        arry[j + 1] = temp;
                    }
                }

            }
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="isAsc"></param>
        public static void SoftBySelect(int[] arry, bool isAsc = true)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            for (int i = 0; i < arry.Length; i++)
            {
                int index = i;
                for (int j = i + 1; j < arry.Length; j++)
                {
                    if (arry[index] > arry[j] == isAsc)
                        index = j;
                }
                int temp = arry[i];
                arry[i] = arry[index];
                arry[index] = temp;
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="isAsc"></param>
        public static void SoftByInsert(int[] arry, bool isAsc = true)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            int current;
            for (int i = 0; i < arry.Length - 1; i++)
            {
                current = arry[i + 1];
                int index = i;
                while (index >= 0 && current < arry[index] == isAsc)
                {
                    arry[index + 1] = arry[index];
                    index--;
                }
                arry[index + 1] = current;
            }
        }
        #endregion

        #region 有一个8个数的数组{1,2,3,3,4,5,6,6}，计算其中不重复数字的个数。
        public static int CalNotRepeat(int[] arry)
        {
            int result = 0;
            if (null == arry)
                throw new Exception("arry不能为null");
            HashSet<int> hs = new HashSet<int>();
            foreach (var item in arry)
                hs.Add(item);
            result = hs.Count;
            return result;
        }

        public static int CalNotRepeatNew(int[] arry)
        {
            int result = 0;
            if (null == arry)
                throw new Exception("arry不能为null");
            List<int> list = new List<int>();
            foreach (var item in arry)
            {
                if (!list.Contains(item))
                    list.Add(item);
            }
            result = list.Count;
            return result;
        }
        #endregion

        #region 打印出由*号组成的倒三角形的图案
        /// <summary>
        /// ******* 4*2-1 要求：	1、输入倒三角的行数，行数范围3-18，对于不在范围的行数，抛出提示.
        /// *****	3*2-1	2、在控制台打印出指定行数的倒三角形。
        /// ***2 (2*2)-1
        /// *1 (1*2)-1
        /// 公式 (n*2)-1
        /// </summary>
        /// <param name="num"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static void PrintTriangle(int num, int min = 3, int max = 18)
        {
            if (num < min || num > max)
                throw new Exception("参数错误。");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Clear();
                string space = "".PadLeft(i, ' ');//生成空格,规则:行首空格数=行数-1
                sb.Append(space);
                string star = "".PadLeft((num - i) * 2 - 1, '*');//生成星号,规则:行号*2-1,行号=num-i
                sb.Append(star);
                Console.WriteLine(sb);
            }
        }
        public static void InvertedPrintTriangle(int num, int min = 3, int max = 18)
        {
            if (num < min || num > max)
                throw new Exception("参数错误。");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Clear();
                string space = "".PadLeft(num - i - 1, ' ');//生成空格,规则:行首空格数=总行数-当前行数-1-1
                sb.Append(space);
                string star = "".PadLeft(i * 2 + 1, '*');//生成星号,规则:行号*2-1,行号=num-i
                sb.Append(star);
                Console.WriteLine(sb);
            }
        }
        public static void PrintTriangleMy(int row, int min = 3, int max = 18)
        {
            if (row < min || row > max)
                throw new Exception("参数错误。");
            while (row > 0)
            {
                Print(row);
                Console.WriteLine("");
                row--;
            }
        }
        public static void Print(int count)
        {
            while (count > 0)
            {
                Console.Write("*");
                count--;
            }
        }
        #endregion

        #region 进制转换
        public static string ConverString(int val, string chars, int length)
        {
            string result = "";
            if (chars.Length < length)
                throw new Exception("参数不合法");
            while (true)
            {
                int temp = val / length;
                if (temp == 0)
                {
                    result += chars[length - 1];
                    break;
                }
                else
                {
                    val = temp;
                    result += chars[length - 1];
                }
            }

            return result;
        }

        public static string Conver(int val, string chars, int length)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> st = new Stack<char>();
            int tempVal = val;
            if (chars.Length < length || val > int.MaxValue || val < int.MinValue)
                throw new Exception("参数不合法");
            if (val < 0)
            {
                val = Math.Abs(val);
                sb.Append("-");
            }
            do
            {
                int next = val / length;
                st.Push(chars[val % length]);
                val = next;
            } while (val > 0);

            while (st.Count > 0)
                sb.Append(st.Pop());

            return sb.ToString();
        }
        #endregion

        #region 求s=a+aa+aaa  例如2+22+222
        public static int Sum3(int num, int length)
        {
            if (!(num > 0 && num < 10 && length > 0))
                throw new Exception("参数不合法");
            int Sum = 0;
            int next = 0;
            for (int i = 0; i < length; i++)
            {
                next = next * 10 + num;
                Sum += next;
            }
            return Sum;
        }
        #endregion

        #region 字符串查找第一个不重复的字母
        ////会有问题 如aaaaaaaaaa
        //public static char? FindChar(string str = "asfgasjfoiwoeqkwzxc")
        //{
        //    if (string.IsNullOrEmpty(str))
        //        throw new Exception("参数不合法");
        //    char? result = null;
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        int count = 0;
        //        for (int j = i + 1; j < str.Length; j++)
        //        {
        //            if (str[i] == str[j])
        //                count++;
        //        }
        //        if (count == 0)
        //        {
        //            result = str[i];
        //            break;
        //        }

        //    }
        //    return result;
        //}
        public static char? FindChar(string str = "asfgasjfoiwoeqkwzxc")
        {
            if (string.IsNullOrEmpty(str))
                throw new Exception("参数不合法");
            char? result = null;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dic.ContainsKey(str[i]))
                    dic[str[i]]++;
                else
                    dic[str[i]] = 1;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (dic[str[i]] == 1)
                {
                    result = str[i];
                    break;
                }
            }
            return result;
        }
        #endregion

        #region  一球从100米高度自由落下，每次落地后反跳回原高度的一半；再落下，求它在第10次落地时，共经过多少米？第10次反弹多高？
        public static void Run(decimal height, decimal next, int count, out decimal sum, out decimal now)
        {
            if (height <= 0 || next >= 1 || next < 0 || count <= 0)
            {
                throw new Exception("参数不合法");
            }
            sum = 0;
            now = 0;
            for (int i = 1; i <= count; i++)
            {
                sum = sum + height + height * next;
                height *= next;
            }

            now = height;
        }
        #endregion

        #region n阶台阶，一次走一步或两步，有多少种走法
        public static int findStep(int n)
        {
            if (n < 0)
                throw new Exception("参数不合法");
            if (n == 0 || n == 1 || n == 2)
                return n;
            return findStep(n - 1) + findStep(n - 2);
        }
        public static int findStep2(int n)
        {
            if (n < 0)
                throw new Exception("参数不合法");
            //if (n == 1)
            //    return 1;
            //else if (n == 2)
            //    return 2;
            if (n == 0 || n == 1 || n == 2)
                return n;
            else if (n == 3)
                return 4;
            return findStep2(n - 1) + findStep2(n - 2) + findStep2(n - 3);
        }
        #endregion

        #region 找出一个数组中重复次数大于minTimes的数字
        public static int[] FindDuplicationLq(int[] arry, uint minTimes)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            List<int> list = new List<int>();
            var goup = arry.GroupBy(m => m);
            var items = goup.Where(p => p.Count() >= minTimes);
            foreach (var item in items)
                list.Add(item.Key);
            return list.ToArray();
        }
        public static int[] FindDuplication(int[] arry, uint minTimes)
        {
            if (null == arry)
                throw new Exception("arry不能为null");
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> list = new List<int>();
            foreach (var item in arry)
            {
                if (dic.ContainsKey(item))
                    dic[item]++;
                else
                    dic.Add(item, 1);
            }
            foreach (var item in dic)
            {
                if (item.Value >= minTimes)
                    list.Add(item.Key);
            }
            return list.ToArray();
        }
        #endregion

        #region 输入一个字符串1234,编写代码打印出来改字符串的所有排列 如1234. 输出所有排列可能：1234 1324 1423 1432。
        public static void permutation(char[] str, int i)
        {
            if (i >= str.Length)
                return;
            if (i == str.Length - 1)
            {
                Console.WriteLine(new string(str));
            }
            else
            {
                for (int j = i; j < str.Length; j++)
                {
                    char temp = str[j];
                    str[j] = str[i];
                    str[i] = temp;
                    permutation(str, i + 1);
                    temp = str[j];
                    str[j] = str[i];
                    str[i] = temp;
                }
            }
        }
        #endregion
    }
}
