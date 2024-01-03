﻿namespace 进程线程与同步
{
    // 1 计算机的核心是CPU，它承担了所有的计算任务。它就像一座工厂，时刻在运行

    // 2 如果工厂的电力有限一次只能供给一个车间使用。也就是说一个车间开工的时候，其他车间就必须停工
    //   背后的合义就是，单个CPU一次只能运行一个任务。(多核CPU可以运行多个任务)

    // 3 进程就好比工厂的车间，它代表CPU所能处理的单个任务。任一时刻，CPU总是运行一个进程，其他进程处于非运行状态

    // 4 一个车间里，可以有很多工人，他们协同完成一个任务

    // 5 线程就好比车间里的工人。一个进程可以包括多个线程

    // 6 车间的空间是工人们共享的，比如许多房间是每个工人都可以进出的。
    //   这象征一个进程的内存空间是共享的，每个线程都可以使用这些共享空间

    // 7 进程就好比工厂，它代表CPU所能处理的单个任务。任一时刻，CPU总是运行一个进程，其他进程处于非运行状态

    // 8 一个防止他人进入的简单方法，就是门口加一把锁(厕所)。先到的人锁上门,后到的人看到上锁，就在门口排队,等锁打开再进去
    //   这就叫”互斥锁”(Mutualexclusion，缩写 Mutex)，防止多个线程同时读写某一块内存区域

    // 9 还有些房间可以同时容纳个人，比如厨房，也就是说，如果人数大于n,多出来的人只能在外面等着，这好比某些内存区域，只能供给固定数目的线程使用

    // 10 这时的解决方法，就是在门口挂n把钥匙、进去的人就取一把钥匙，出来时再把挂回原处，后到的人发现钥息架空了，就知道必须在门口排队等着了
    //    这种做法叫做"信号量”(Semaphore)，用来保证多个线程不会互相冲突
    //    不难看出，mutex是semaphore的一种特殊情况(n=1)时，也就是说，完全可以用后者代替前者，但是因为mutex较为简单且效率高，所以在必须保证资源独占的青况下，还是采用这种设计

    // 11，操作系统的设计，因此可以归结为三点
    //      (1)以多进程形式，允许多个任务同时运行
    //      (2)以多线程形式，允许单个任务分成不同的部分运行 
    //      (3) 提供协调机制一方面防止进程之间和线程之间产生冲突，另一方面允许进程之间和线程之间共享资源
    internal class Program
    {
        // Main主线程，代码从上到下执行
        static void Main(string[] args)
        {
            // 1 通过委托开启一个新的线程
            // 2 通过Thread类开启一个新的线程

            Thread thread = new Thread(Download);
            thread.Start();
            Console.WriteLine("In Main");

            Thread thread1 = new Thread(() =>{
                Console.WriteLine("(Lambda) Download Start...");
                Thread.Sleep(3000);
                Console.WriteLine("(Lambda) Download End...");
            });
            //thread1.IsBackground = true;  // 这时候Main方法结束，应用程序就会退出，所以这个线程看不到End结束
            thread1.Start();

            // 只要有前台程序在运行，应用程序就不会退出，如果有多个前台程序在运行，但是Main方法结束了，应用程序也不会退出
            // 直到所有的前台程序都结束了，应用程序才会退出，所有前台线程结束后，后台线程会自动结束
            // 用Thread类创建的线程默认是前台线程，用ThreadPool创建的线程默认是后台线程
            // 用IsBackground属性可以设置线程是否为后台线程

            // 3 通过线程池开启一个新的线程
            // 线程池中的线程都是后台线程，所以当Main方法结束后，应用程序就会退出，且不能被修改为前台线程
            ThreadPool.QueueUserWorkItem(Download, "http://www.baidu.com");
            ThreadPool.QueueUserWorkItem(Download, "http://www.sina.com");

            
        }

        static void Download(object str)
        {
            Console.WriteLine($"Download {str} Start...");
            Thread.Sleep(2000);
            Console.WriteLine($"Download {str} End...");
        }
    }
}
