#include <thread>
#include <iostream>
#include <time.h>
using namespace std;

void Func1(int* num,int min,int max)
{
	for (int i = min; i < max; i++)
	{
		*num += i;
	}
}

int main(void)
{
	int a = 0;
	double start = clock();
	double end = 0;
	thread t1(Func1,&a,0,3333);
	thread t2(Func1,&a,3333,6666);
	thread t3(Func1, &a,6666,10001);

	t1.join();
	t2.join();
	t3.join();

	end = clock();

	cout << a <<" 걸린 시간 : "<<(double)end - start << endl;
}