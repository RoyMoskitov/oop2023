#include <iostream>
#include "forecast.h"
#include "forecast2.h"
#include <string>
#include <time.h>
#include <format>
#include <algorithm>

namespace Prog2 {

	Forecast::Forecast(int csize, Weather* a) {
		if (csize <= 0) throw std::invalid_argument("invalid current size");
		//if (msize < 0) throw std::invalid_argument("invalid max size");
		cs = csize;
		while (cs > ms) ms *= 2;
		arr = new Weather[ms];
		for (int i = 0; i < csize; ++i) arr[i] = a[i];
	}
  
	Forecast::Forecast() {
		arr = new Weather[1];
		cs = 0;
		ms = 1;
		//Weather a;
		//arr = nullptr;
		//arr[0] = a;
	}

	Forecast::Forecast(Forecast &old)
	{
		arr = new Weather[old.ms];
		cs = old.cs;
		ms = old.ms;
		for (int i = 0; i < cs; ++i) {
			arr[i] = old.arr[i];
		}
	}

	Forecast::Forecast(int csize, Weather a) {
		if (csize <= 0) throw std::invalid_argument("invalid current size");
		//if (msize <= 0) throw std::invalid_argument("invalid max size");
		cs = csize;
		while (cs > ms) ms *= 2;
		//ms = msize;
		arr = new Weather[ms];
		for (int i = 0; i < csize; ++i) arr[i] = a;
	}

	Weather *Forecast::change_size(int newsize, int oldsize) {
		Weather* newbuf = new Weather[newsize];
		std::copy(arr, arr+oldsize, newbuf);
		delete[] arr;
		arr = nullptr;
		return newbuf;
	}

	Forecast& Forecast::operator = (Forecast& n) {
		arr = change_size(n.getMS(), cs);
		for (int i = 0; i < n.getCS(); ++i) {
			arr[i] = n.getDF(i+1);
		}
		cs = n.getCS();
		ms = n.getMS();
		return *this;
	}

	Forecast& Forecast::operator+= (Weather ob) {
		int old = ms;
		cs++;
		if (cs >= ms) {
			while (cs > ms) ms *= 2;
			arr = change_size(ms, old);
		}
		arr[cs - 1] = ob;
		return *this;
	}

	void Forecast::addDF(Weather ob) {
		int old = ms;
		cs++;
		if (cs >= ms) {
			while (cs > ms) ms *= 2;
			arr = change_size(ms, old);
		}
		arr[cs-1] = ob;
	}

	void Forecast::delW(int num) {
		if (cs == 0) throw std::invalid_argument("Forecast is empty");
		if (num > cs || num < 0) throw std::invalid_argument("Invalid number");
		for (int i = num; i < cs-1; ++i) arr[i] = arr[i + 1];
		cs--;
	}

	void Forecast::delM() {
		for (int i = 0; i < cs; ++i) {
			if (arr[i].mistake() == 1) delW(i);
		}
	}

	Weather& Forecast::getDF(int i) {
		if (i > cs || i <= 0 ) throw std::invalid_argument("Invalid number");
		return arr[i-1];
	}

	Weather& Forecast::Coldest(std::tm st, std::tm fin) {
		Weather ob1;
		Weather ob2;
		ob1.setD(st);
		ob2.setD(fin);
		int ind;
		double min = 99999;
		for (int i = 0; i < cs; ++i) {
			if ((arr[i] < ob2 || arr[i] == ob2) && (ob1 < arr[i] || arr[i] == ob1)) {
				if (arr[i].midT() <= min) {
					min = arr[i].midT();
					ind = i;
				}
			}
		}
		return arr[ind];
	}

	Weather& Forecast::CloseSun(std::tm now) {
		std::tm min_date;
		min_date.tm_year = 9999;
		min_date.tm_mon = 9;
		min_date.tm_mday = 9;
		Weather min(min_date, 0, 0, 0, 0);
		int ind = -1;
		Weather n(now, 0, 0, 0, 0);
		for (int i = 0; i < cs; ++i) {
			if (n < arr[i] && arr[i] < min && arr[i].getW() == 1) {
				min_date = arr[i].getD();
				min.setD(min_date);
				ind = i;
			}
		}
		if (ind == -1) {
			throw std::invalid_argument("No sun these days");
		}
		return arr[ind];
	}

	bool customer_sorter(Weather x, Weather  y) {
		if (x == y) return 0;
		else return x < y;
	}

	std::ostream& operator<<(std::ostream& os, Forecast& obj) {
		for (int i = 0; i < obj.cs; ++i) 
			os << obj[i] << std::endl;
		return os;
	}

	std::istream& operator>>(std::istream& is, Forecast& obj) {
		obj.ms = 1;
		int csize;
		is >> csize;
		Weather *array = new Weather[csize];
		if (is.good())
		{
			if (csize < 1)
				is.setstate(std::ios::failbit);
			else {
				for (int i = 0; i < csize; ++i) 
					is >> array[i];
			}
		}
		if (is.good()) {
			obj.ms = csize;
			obj.cs = csize;
			delete[] obj.arr;
			obj.arr = array;
		}
		return is;
	}

	void Forecast::sortF() {
		std::sort(arr, arr + cs, customer_sorter);
	}

	Forecast& Forecast::sortM(int mon, int year, Forecast &n) {
		delete[] n.arr;
		n.cs = 0;
		n.ms = 1;
		n.arr = new Weather[1];
		for (int i = 0; i < cs; ++i) {
			if (getDF(i+1).getD().tm_mon == mon && getDF(i + 1).getD().tm_year == year) n += (getDF(i+1));
		}
		n.sortF();
		//n.operator<<(std::cout);
		return n;
	}

	bool search_ind(int *del_ind, int j, int size) {
		for (int i = 0; i < size; ++i) {
			if (del_ind[i] == j) return true;
 		}
		return false;
	}

	void Forecast::Unite() {
		Weather* q = new Weather;
		for (int i = 0; i < cs; ++i) {
			for (int j = 0; j < cs; ++j) {
				if (j != i && arr[i] == arr[j]) {
					arr[i] += arr[j];
					std::swap(arr[cs - 1], arr[j]);
					cs--;
				}
			}
		}
		//Weather* q = new Weather[ms];
		//int k = 0, size=0;
		//int* del_ind = new int[cs];
		//for (int i = 0; i < cs; ++i) {
		//	for (int j = i+1; j < cs; ++j) {
		//		if (arr[i] == arr[j] && search_ind(del_ind, i, k) == false) {
		//			del_ind[k] = j;
		//			q[k] = (arr[i] += arr[j]);
		//			k++;
		//		}
		//	}
		//}
	}

	Forecast::~Forecast() {
		delete[] arr;
	}

	void Forecast::showFull() {
		for (int i = 0; i < cs; ++i) {
			std::cout << "Day forecast number " << i + 1 << ":" << std::endl;
			this->getDF(i + 1).show();
		}
	}
}