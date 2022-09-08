#include <thread>
#include <iostream>
#include <time.h>
#include <mutex>
using namespace std;

void Func1(int* num,int min,int max,mutex* m, mutex* m2)
{
	for (int i = min; i < max; i++)
	{
		m->lock();
		m2->lock();
		*num += i;
		m->unlock();
		m->unlock();
	}
}
void Func2(int* num, int min, int max, mutex* m, mutex* m2)
{
	for (int i = min; i < max; i++)
	{
		m->lock();
		*num += i;
		m->unlock();
	}
}

int main(void)
{
	mutex m;
	mutex t;
	int a = 0;
	double start = clock();
	double end = 0;
	thread t1(Func1,&a,0,3333,&m);
	thread t2(Func1,&a,3333,6666, &m);
	thread t3(Func1, &a,6666,10001, &m);

	t1.join();
	t2.join();
	t3.join();

	end = clock();

	cout << a <<" 걸린 시간 : "<<(double)end - start << endl;
}