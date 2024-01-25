#include <iostream>
#include "forecast.h"
#include <string>
#include <time.h>
#include <format>
namespace Prog2 {

	Weather::Weather() {
		p = tm = td = te = 0;
		date.tm_mday = 1;
		date.tm_mon = 1;
		date.tm_year = 2023;
		w = sunny;
	}

	Weather::Weather(std::tm d, double tempm, double tempd, double tempe, double prec) {
		if (tempm < -273 || tempd < -273 || tempe < -273) {
			throw std::invalid_argument("invalid temperature");
		}
		if (d.tm_mday < 0 || d.tm_mon < 0 || d.tm_year < 0) {
			throw std::invalid_argument("invalid date");
		}
		if (prec < 0) {
			throw std::invalid_argument("invalid precipitation");
		}
		date = d;
		p = prec;
		tm = tempm;
		td = tempd;
		te = tempe;
		int r = rand() % 2;
		if (prec == 0 && r == 1) w = sunny;
		else if (prec == 0 && r == 0) w = cloudy;
		else if ((tm + td + te) / 3 < 0) w = snowy;
		else w = rainy;
	}

	Weather::Weather(std::tm d, double tempm, double tempd, double tempe, double prec, Condition weather) {
		if (weather < 1 || weather > 4) {
			throw std::invalid_argument("invalid weather condition");
		}
		if (tempm < -273 || tempd < -273 || tempe < -273) {
			throw std::invalid_argument("invalid temperature");
		}
		if (d.tm_mday < 0 || d.tm_mon < 0 || d.tm_year < 0) {
			throw std::invalid_argument("invalid date");
		}
		if (prec < 0) {
			throw std::invalid_argument("invalid precipitation");
		}
		date = d;
		p = prec;
		tm = tempm;
		td = tempd;
		te = tempe;
		w = weather;
	}
	// сеттеры (setter)

	Weather& Weather::setTM(double t) {
		if (t < -273) {
			throw std::invalid_argument("invalid temperature");
		}
		tm = t;
		return *this;
	}
	Weather& Weather::setTD(double t) {
		if (t < -273) {
			throw std::invalid_argument("invalid temperature");
		}
		td = t;
		return *this;
	}
	Weather& Weather::setTE(double t) {
		if (t < -273) {
			throw std::invalid_argument("invalid temperature");
		}
		te = t;
		return *this;
	}
	Weather& Weather::setD(std::tm d) {
		if (d.tm_mday < 0 || d.tm_mon < 0 || d.tm_year < 0) {
			throw std::invalid_argument("invalid date");
		}
		date = d;
		return *this;
	}
	Weather& Weather::setP(double prec) {
		if (prec < 0) {
			throw std::invalid_argument("invalid precipitation");
		}
		p = prec;
		return *this;
	}
	Weather& Weather::setW(Condition weather) {
		if (weather < 1 || weather > 4) {
			throw std::invalid_argument("invalid weather condition");
		}
		w = weather;
		return *this;
	}

	bool Weather::mistake() {
		if (p > 1500 || tm < -100 || tm > 60 || td < -100 || td > 60 || te < -100) return true;
		if (te > 60 || (w == 4 && tm > 0 && td > 0 && te > 0) || ((w == 1 || w == 2) && p != 0)) return true;
		return false;
	}
	
	/*int Weather::comp(const Weather& rhs) const {
		if (date.tm_year < rhs.date.tm_year) return -1;
		else if (date.tm_mon < rhs.date.tm_mon && date.tm_year == rhs.date.tm_year) return -1;
		else if (date.tm_mday < rhs.date.tm_mday && date.tm_mon == rhs.date.tm_mon && date.tm_year == rhs.date.tm_year) return -1;
		else if (date.tm_mday == rhs.date.tm_mday && date.tm_mon == rhs.date.tm_mon && date.tm_year == rhs.date.tm_year) return 0;
		else return 1;
	}*/

	void Weather::show() {
		std::cout << "Current Date: " << date.tm_mday << '/' << (date.tm_mon) << '/'
			<< (date.tm_year) << std::endl;
		//std::cout << "weather forecast for " << ctime_s(str, sizeof(str), &date) << std::endl;
		std::cout << "Temperature dynamic: 6 a.m. - " << tm << "; 12 a.m. - " << td << "; 6 p.m. - " << te << std::endl;
		std::cout << "Perception - " << p << std::endl;
		std::cout << "Weather phenomenon - ";
		switch (w) {
		case(1): std::cout << "sunny";
			break;
		case(2): std::cout << "cloudy";
			break;
		case(3): std::cout << "rainy";
			break;
		case(4): std::cout << "snowy";
			break;
		}
		std::cout << std::endl;
	}

	Weather &Weather::operator += (const Weather& rhs) {
		if (this->operator==(rhs)) {
			double t = (rhs.p + p) / 2;
			this->setP(t);
			t = (rhs.tm + tm) / 2;
			this->setTM(t);
			t = (rhs.td + td) / 2;
			setTD(t);
			t = (rhs.te + te) / 2;
			setTE(t);
			Condition k = (Condition) std::max(w, rhs.w);
			this->setW(k);
			return *this;
		}
		return *this;
	}


};