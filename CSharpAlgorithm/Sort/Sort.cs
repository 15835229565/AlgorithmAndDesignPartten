﻿/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：Sort
* 创 建 者：Qing
* 创建时间：2018-05-06 15:38:21
* CLR 版本：4.0.30319.42000
* 保存的文件名：Sort
* 文件版本：V1.0.0.0
*
* 功能描述：N/A 
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 数据结构与算法C#版笔记--排序(Sort)-上 - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/12/20/1911472.html
 */
namespace CSharpAlgorithm
{
    public class Sort
    {
        #region 1、直接插入排序(InsertOrder)
        //思路：从第二个元素开始向后遍历，检查本身(后面称之为tmp)与前面相邻元素的大小，如果发现前面的元素更大，则依次从近及远（即倒序遍历）检查前面的所有元素，将比自身元素大的元素依次后移，这样最终将得到一个空位，将tmp元素插在这个位置即可.
        /// <summary>
        /// 直接插入排序法
        /// </summary>
        /// <param name="lst"></param>
        static void InsertSort(int[] lst)
        {
            int _circleCount = 0;
            //外循环从第二个元素开始从前向后遍历
            for (int i = 1; i < lst.Length; i++)
            {
                _circleCount++;
                //Console.WriteLine("外循环i=" + i);
                //如果发现某元素比前一个元素小
                if (lst[i] < lst[i - 1])
                {
                    int tmp = lst[i];
                    int j = 0;
                    //则该元素前面的元素，从后到前遍历，依次后移，直接找到应该插入的空档在哪里(这样tmp元素就找到了自己的位置)
                    for (j = i - 1; j >= 0 && tmp < lst[j]; j--)
                    {
                        //如果发现有比tmp小的元素，则将元素后移一位(从而把自身空出来，形成一个空档，以方便如果前面还有更小的元素时，可以继续向后面的空档移动)
                        lst[j + 1] = lst[j];
                        _circleCount++;
                        //Console.WriteLine("内循环i=" + i + "，内循环j=" + j);
                    }
                    //Console.WriteLine("j={0}", j);
                    //运行到这里时，j已经是空档的前一个下标
                    lst[j + 1] = tmp;
                }
            }
            Console.WriteLine("InsertOrder共循环了{0}次", _circleCount);
        }
        // 点评：最好情况下，如果所有元素(N个)已经排好序了，则外循环跑N-1次，内循环一次也进不了，即0次，时间复杂度为O(N)；最坏情况下，所有元素反序，外循环N-1次，内循环为i（i从1到N-1），时间复杂度为O(N*N)；所以元素越有序列，该方法效率越高，其时间复杂度从O(N)到O(N*N)之间，此外，该方法是一种稳定排序。(注：若数组中有相同值的元素时，经过某方法排序后，这二个相同值的元素先后顺序仍然不变，则称这种排序方法为稳定的，反之为不稳定排序方法)
        #endregion

        #region 2、冒泡排序法(BubbleSort)
        // 思路：从最后一个元素开始向前遍历，依次检查本元素与前面相邻元素的大小，如果前面的元素更大，则交换位置，如此反复，直到把自己前移到合适的位置（即 相当于后面的元素，通过这种比较，按照从小到大将不断移动前面来，就象气泡从下面向上冒一样）
        /// <summary>
        /// 冒泡排序法
        /// </summary>
        /// <param name="lst"></param>
        static void BubbleSort(int[] lst)
        {
            int _circleCount = 0;//辅助用，可以去掉

            int tmp;
            for (int i = 0; i < lst.Length; i++)
            {
                for (int j = lst.Length - 2; j >= i; j--)
                {
                    if (lst[j + 1] < lst[j])
                    {
                        tmp = lst[j + 1];
                        lst[j + 1] = lst[j];
                        lst[j] = tmp;
                    }

                    _circleCount++;
                }
            }

            Console.WriteLine("BubbleOrder共循环了{0}次", _circleCount);
        }
        // 点评：与插入排序法类似，最好情况是所有元素已经排好序，这样只跑外循环，内循环因为if判断不成立，直接退出；最坏情况是所有元素反序，外循环和内循环每次都要处理，因此时间复杂度跟插入排序法完全相同，同样这也是一种稳定排序。
        #endregion

        #region 3、简单选择排序法 (SimpleSelectOrder)
        // 思路：先扫描整个数组，找出最小的元素，然后跟第一个元素交换(这样，第一个位置的元素就排好了)，然后从第二个元素开始继续扫描，找到第二小的元素，跟第二个元素交换（这样，第二个位置的元素也排好了）...如此反复
        /// <summary>
        /// 简单选择排序法
        /// </summary>
        /// <param name="lst"></param>
        static void SimpleSelectSort(int[] lst)
        {
            int _circleCount = 0;//辅助用

            int tmp = 0;
            int t = 0;
            for (int i = 0; i < lst.Length; i++)
            {
                t = i;
                //内循环，找出最小的元素下标
                for (int j = i + 1; j < lst.Length; j++)
                {
                    if (lst[t] > lst[j])
                    {
                        t = j;
                    }
                    _circleCount++;
                }
                //将最小元素[下标为t]与元素i互换
                tmp = lst[i];
                lst[i] = lst[t];
                lst[t] = tmp;
            }
            Console.WriteLine("SimpleSelectSort共循环了{0}次", _circleCount);
        }
        // 点评：跟冒泡法很类似，不过应该注意到，这里的元素交换操作是在内循环外，即不管如何这个交换操作是省不了的，所以其时间复杂度均为O(N*N)，同样这也是一个稳定排序。
        #endregion

        #region 4、快速排序(QuickOrder)
        // 思路：以数组中间的元素做为分界线（该元素称为支点），扫描其它元素，比支点小的放在左侧，比支点大的放在右侧，这样就把数组分成了二段(即做了一次粗放的大致排序)，然后对每一段做同样的处理（即二段变四段，4段变8段...），直到最后每一段只有一个元素为止(没错，该方法是一个递归调用)
        /// <summary> 　　
        /// 快速排序 　　
        /// </summary> 　　
        /// <param name="arr">待排序数组</param> 　　
        /// <param name="left">数组第一个元素索引Index</param> 　　
        /// <param name="right">数组最后一个元素索引Index</param> 　　
        static void QuickSort(int[] arr, int left, int right)
        {
            //左边索引小于右边，则还未排序完成 　　
            if (left < right)
            {
                //取中间的元素作为比较基准，小于他的往左边移，大于他的往右边移 　　
                int middle = arr[(left + right) / 2];
                //因为while中要做++与--的操作，所以这里先将i,j各自换外扩张一位
                int i = left - 1;
                int j = right + 1;
                while (true)
                {
                    while (arr[++i] < middle) ;//如果前半部的元素值本身就比支点小，则直接跳过

                    while (arr[--j] > middle) ;//如果后半部的元素值本身就比支点大，则直接跳过

                    //因为前半段是向后遍历，而后半段是向前遍历，所以如果二者碰到了，
                    //则说明所有元素都被扫过了一遍，完成退出
                    if (i >= j)
                    {
                        break;
                    }

                    //经过前面的处理后，如果发现有放错位置的元素，则将二者对换
                    int tmp = arr[i];
                    arr[j] = arr[i];
                    arr[i] = tmp;

                }

                //经过上面的while循环后，元素已被分成左右二段（左段小于支点，右段大于支点）

                //递归调用，处理左段
                QuickSort(arr, left, i - 1);

                //递归调用，处理右段
                QuickSort(arr, j + 1, right);
            }
        }
        // 点评：每次从中间分成二段，然后再中分为二段，如此反复...这跟二叉树很相似（每次分段，相当于树中的某个节点分成二叉），最好情况下所有元素已经排好序，最终树的左右分支数大致相同（即左右分支长度大致相同），所以分解次数为树的高度log2N，而最坏情况下，所有元素反序，这时分解得到的树相当于一个单右支二叉树（即一个右分支超级长，没有左分支的怪树），即时间复杂度范围为nLog2N 至 N*N。此外，快速排序是一种不稳定的排序（从代码就能看出来，即使是二个相同值的节点，在分段过程中，也有可能被交换顺序）
        #endregion

        #region 5、堆排序(HeapSort)
        //思路为：
        //1、先将给定待排序的数组通过一定处理，形成一个“最大堆”
        //2、然后将根节点(root)与最后一个序号的节点(lastNode)对换，这样值最大的根节点，就“沉”到所有节点最后了(也就是垫底了)，下轮处理就不用理会它了.
        //3、因为第2步的操作，剩下的这些节点肯定已经不满足最大堆的定义了(因为把小值的末节点换成根节点了，它的子节点中肯定会有值比它大的)，然后再类似第1步的处理，把这些剩下的节点重新排成“最大堆”
        //4、重复第2步的操作，将“新最大堆的根节点”与“新最大堆的末结点”(其实就是整个数组的倒数第二个节点，因为在第一轮处理中，最大值的节点已经沉到最后了，所以新最大堆的最末节点就是整个数组的倒数第二个节点)对换，这样第二大的元素也沉到适当的位置了，以后就不用理它了，然后继续把剩下的节点，重组成最大堆
        //5、反复以上过程，直到最后剩下的节点只剩一个为止（即没办法再继续重组成最大堆），这时排序结束，最后剩下的节点，肯定就是值最小的
        //理解以上思路后，堆排序就拆分成了二个问题：
        //A、如何将数组指定范围的N个元素创建一个"最大堆"？
        //B、如何用一定的算法，反复调用A中的"最大堆创建"方法，以处理剩下的节点，直到最终只剩一个元素为止
        //    创建最大堆的算法，完全依赖于完全二叉树的数学特性，代码如下：

        /// <summary>
        /// 创建最大堆
        /// </summary>
        /// <param name="arr">待处理的数组</param>
        /// <param name="low">指定连续待处理元素范围的下标下限</param>
        /// <param name="high">指定连续待处理元素范围的下标上限</param>
        static void CreateMaxHeap(int[] arr, int low, int high)
        {
            if ((low < high) && (high <= arr.Length - 1))
            {
                int j = 0, k = 0, t = 0;

                //根据完全二叉树特性，前一半元素都是父节点，所以只需要遍历前一半即可
                for (int i = high / 2; i >= low; --i)
                {
                    k = i;
                    t = arr[i];//暂存当前节点值
                    j = 2 * i + 1;//计算左节点下标(注意：数组下标是从0开始的，而完全二叉树的序号是从1开始的，所以这里的2*i+1是左子节点，而非右子节点！)                    
                    while (j <= high) //如果左节点存在
                    {
                        //如果右节点也存在，且右节点更大
                        if ((j < high) && (j + 1 <= high) && (arr[j] < arr[j + 1]))
                        {
                            ++j;//将j值调整到右节点的序号，即经过该if判断后，j对应的元素就是i元素的左、右子节点中值最大的
                        }

                        //如果本身节点比子节点小
                        if (t < arr[j])
                        {
                            arr[k] = arr[j];//将自己节点的值，更新为左右子节点中最大的值

                            //然后保存左右子节点中最大元素的下标(因为实际上要做的是将最大子节点与自身进行值交换，
                            //上一步只完成了交换值的一部分，后面还会继续处理才能完成整个交换)
                            k = j;
                            j = 2 * k + 1;//交换后，j元素就是父节点了，然后重新以j元素为父节点，继续考量其"左子节点"，准备进入新一轮while循环
                        }
                        else //如果本身已经是最大值了，则说明元素i所对应的子树，已经是最大堆，则直接跳出循环
                        {
                            break;
                        }
                    }
                    //接上面的交换值操作，将最大子节点的元素值替换为t(因为最近的一次if语句中，k=j 了，
                    //所以这里的arr[k]其实就是arr[j]=t，即完成了值交换的最后一步，
                    //当然如果最近一次的if语句为false,根本没进入，则这时的k仍然是i，维持原值而已)
                    arr[k] = t;
                }
            }
        }


        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arr"></param>
        static void HeapSort(int[] arr)
        {
            int tmp = 0;
            //初始时，将整个数组排列成"初始最大堆"
            CreateMaxHeap(arr, 0, arr.Length - 1);
            for (int i = arr.Length - 1; i > 0; --i)
            {
                //将根节点与最末结点对换
                tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;
                //去掉沉底的元素，剩下的元素重新排列成“最大堆”
                CreateMaxHeap(arr, 0, i - 1);
            }
        }
        // 点评：这是一种思维方式很独特的排序方式，时间复杂度跟快速排序类似，也是跟二叉树有关，为O(Nlog2N)，同样它也是一种不稳定的排序。
        #endregion

        #region 6、归并排序算法（MergeSort）
        // 思路：将数组中的每个元素看作一个小序列，然后二二合并成一个有序的新序列(这样序列个数从N变成了N/2，但是每个小序列的长度从1变成2)，然后继续将这些新序列二二合并，得到N/4个序列(每个序列的长度从2变成4)，如此反复，最终得到一个全部排列好的完整序列。这也是算法中"分治法"的经典案例之一，即分而治之。
        /// <summary>
        /// 归并处理
        /// </summary>
        /// <param name="arr">需要归并处理的数组</param>
        /// <param name="len">每段小序列的长度</param>
        static void Merge(int[] arr, int len)
        {
            int m = 0; //临时顺序表的起始位置
            int low1 = 0; //第1个有序表的起始位置
            int high1; //第1个有序表的结束位置
            int low2; //第2个有序表的起始位置
            int high2; //第2个有序表的结束位置
            int i = 0;
            int j = 0;
            //临时表，用于临时将两个有序表合并为一个有序表
            int[] tmp = new int[arr.Length];

            //归并处理
            while ((low1 + len) < arr.Length)
            {
                low2 = low1 + len; //第2个有序表的起始位置
                high1 = low2 - 1; //第1个有序表的结束位置

                //第2个有序表的结束位置
                high2 = ((low2 + len - 1) < arr.Length) ? low2 + len - 1 : arr.Length - 1;

                i = low1;
                j = low2;

                //如果二个有序表都还没整完
                while ((i <= high1) && (j <= high2))
                {

                    if (arr[i] <= arr[j])//如果 第1个有序表的元素小于第2个有序表的对应元素，则直接复制第1个有序表的元素到临时表
                    {
                        tmp[m++] = arr[i++];
                    }
                    else//否则，复制第2个有序表的元素到临时表
                    {
                        tmp[m++] = arr[j++];
                    }
                }

                //经过上面的处理后，如果第1个有序表还有元素
                while (i <= high1)
                {
                    tmp[m++] = arr[i++];
                }

                //经过上面的处理后，如果第2个有序表还有元素
                while (j <= high2)
                {
                    tmp[m++] = arr[j++];
                }

                low1 = high2 + 1;//将low1"指针"指到“处理完的2个有序表”之后，以方便下面将剩余未处理完的元素复制到临时表
            }

            i = low1;

            //将尚未处理到的元素复制到临时表
            while (i < arr.Length)
            {
                tmp[m++] = arr[i++];
            }

            //将临时表的元素复制到原数组
            for (i = 0; i < arr.Length; ++i)
            {
                arr[i] = tmp[i];
            }
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arr"></param>
        static void MergeSort(int[] arr)
        {
            int k = 1; //归并增量
            while (k < arr.Length)
            {
                Merge(arr, k);
                k *= 2;
            }
        }

        // 点评：俩俩合并，又是跟2有关的，哈哈，计算机领域真的很2啊！所以其时间复杂度又是O(Nlog2N），但是该算法需要很多的临时数组，所以其空间复杂度较其它算法都要大一些为O(N)，此外它是稳定的排序方法。
        #endregion

        /* 排序方法小结：(原书的小结还算不错，就懒得自己再写了，直接从原电子书上copy过来记录下)
         * 排序在计算机程序设计中非常重要，上面介绍的各种排序方法各有优缺点，适用的场合也各不相同。
         * 在选择排序方法时应考虑的因素有：
         *     （1）待排序记录的数目 n 的大小；
         *     （2）记录本身除关键码外的其它信息量的大小；
         *     （3）关键码(即元素值)的情况；
         *     （4）对排序稳定性的要求；
         *     （5）语言工具的条件，辅助空间的大小等。
         *  综合考虑以上因素，可以得出如下结论：
         *      （1）若排序记录的数目 n 较小（如 n≤50）时，可采用直接插入排序或简单选择排序。由于直接插入排序所需的记录移动操作较简单选择排序多，因而当记录本身信息量较大时，用简单选择排序比较好。
         *      （2）若记录的初始状态已经按关键码基本有序，可采用直接插入排序或冒泡排序。
         *      （3）若排序记录的数目n较大，则可采用时间复杂度为O（nlog2n）的排序方法（如快速排序、堆排序或归并排序等）。
         *           快速排序的平均性能最好，在待排序序列已经按关键码随机分布时，快速排序最适合。快速排序在最坏情况下的时间复杂度是O（n2），而堆排序在最坏情况下的时间复杂度不会发生变化，并且所需的辅助空间少于快速排序。但这两种排序方法都是不稳定的排序，若需要稳定的排序方法，则可采用归并排序。
         *      （4）前面讨论的排序算法，都是采用顺序存储结构。在待排序的记录非常多时，为避免花大量的时间进行记录的移动，可以采用链式存储结构。直接插入排序和归并排序都可以非常容易地在链表上实现，但快速排序和堆排序却很难在链表上实现。此时，可以提取关键码建立索引表，然后对索引表进行排序。也可以引入一个整形数组 t[n]作为辅助表，排序前令t[i]=i，1≤i≤n。若排序算法中要求交换记录 R[i]和 R[j]，则只须交换 t[i]和 t[j]即可。排序结束后，数组 t[n]就存放了记录之间的顺序关系
         *
         */
    }
}
