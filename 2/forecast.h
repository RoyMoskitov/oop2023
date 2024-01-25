#ifndef OOPPROG2_WEATHER_H
#define OOPPROG2_WEATHER_H

/**
* @file forecast.h
* @brief This file consists of the Weather class.
*/

#include <string>
#include <cmath>

namespace Prog2 {

	enum Condition {sunny = 1, cloudy = 2, rainy = 3, snowy = 4};
	/**
	* @class Weather
	*
	* @brief One daily forecast.
	*
	* The Weather consists of the date, weather during the morning, day and evening, 
	* amount of perception and weather condition 
	*/
	class Weather {

	private:
		std::tm date;
		double td = 0;
		double te = 0;
		double tm = 0;
		double p = 0;//осадки
		Condition w = sunny; //погода, 1-солнце, 2-облачно, 3-дождь, 4-снег
	public:
		/**
		* @brief Constructor with 6 initialising values: 3 temperatures, date, perception and condition.
		*
		 * Constructs a Weather object with the given values.
		*
		* @param std::tm d The date.
		* @param tm The weather during the morning.
		* @param td The weather during the day.
		* @param te The weather during the evening.
		* @param prec Amount of perception
		* @param weather The weather condition
		*
		* @throws std::invalid_argument If the values are out of range.
		*/
		inline explicit Weather(std::tm d, double tm, double td, double te, double prec, Condition weather);
		/**
		* @brief Constructor with 5 initialising values: 3 temperatures, date, perception.
		*
		* Constructs a Weather object with the given values, weather condition is chosen automatically.
		*
		* @param std::tm d The date.
		* @param tm The weather during the morning.
		* @param td The weather during the day.
		* @param te The weather during the evening.
		* @param prec Amount of perception
		*
		* @throws std::invalid_argument If the values are out of range.
		*/
		inline explicit Weather(std::tm d, double tm, double td, double te, double prec);
		/**
		* @brief Default constructor with 6.
		*
		* Constructs a Weather object automatically.
		*
		*/
		inline explicit Weather();
		/**
		* @brief Sets the temperature during the morning.
		*
		* @param t Temperature during the morning 
		* 
		* @throws std::invalid_argument If the value is out of range.
		* 
		* @return *this Current object 
		*/
		Weather& setTM(double t);
		/**
		* @brief Sets the temperature during the day.
		*
		* @param t Temperature during the day
		*
		* @throws std::invalid_argument If the value is out of range.
		*
		* @return *this Current object
		*/
		Weather& setTD(double t);
		/**
		* @brief Sets the temperature during the evening.
		*
		* @param t Temperature during the evening
		*
		* @throws std::invalid_argument If the value is out of range.
		*
		* @return *this Current object
		*/
		Weather& setTE(double t);
		/**
		* @brief Sets the date.
		*
		* @param date Date of the forecast 
		*
		* @throws std::invalid_argument If the value is out of range.
		*
		* @return *this Current object
		*/
		Weather& setD(std::tm date);
		/**
		* @brief Sets perception.
		*
		* @param p Amount of perception
		*
		* @throws std::invalid_argument If the value is out of range.
		*
		* @return *this Current object
		*/
		Weather& setP(double p);
		/**
		* @brief Sets weather condition.
		*
		* @param t Temperature during the morning
		*
		* @throws std::invalid_argument If the value is out of range.
		*
		* @return *this Current object
		*/
		Weather& setW(Condition w);
		/**
		* @brief Get the temperature during the morning.
		*
		* @return tm Temperature during the morning.
		*/
		double getTM() const { return tm; }
		/**
		* @brief Get the temperature during the day.
		*
		* @return td Temperature during the day.
		*/
		double getTD() const { return td; }
		/**
		* @brief Get the temperature during the evening.
		*
		* @return te Temperature during the evening.
		*/
		double getTE() const { return te; }
		/**
		* @brief Get the date.
		*
		* @return std::tm date The date.
		*/
		std::tm getD() const { return date; }
		/**
		* @brief Get the amount of perception.
		*
		* @return p Amount of perception.
		*/
		double getP() const { return p; }
		/**
		* @brief Get the weather condition.
		*
		* @return w Weather condition.
		*/
		int getW() const { return w; }
		/**
		* @brief Get the average temperature.
		*
		* @return (tm+td+te)/3 average temperature.
		*/
		double midT() const { return (tm + td + te) / 3; };
		/**
		* @brief determines whether the daily forecast is correct.
		*
		* @return true if daily is incorrect.
		* @return true if daily is correct.
		*/
		bool mistake();
		//int comp(const Weather& rhs) const;//1-первый новее, 0-одинакого, -1-второй новее
		/**
		* @brief Outputs daily forcast with explanations.
		*
		*/
		void show();
		/**
		* @brief Output operator for daily forcast.
		*
		* Writes the content of the Weather object.
		* 
		* @param os  The output stream.
		* @param obj The Weather object.
		* @return std::ostream& An output stream.
		*/
		friend std::ostream& operator << (std::ostream& os, Weather &obj) {
			return os << (obj.getD()).tm_mday << " " << (obj.getD()).tm_mon << " " << (obj.getD()).tm_year << " " <<
				(obj.getTM()) << " " << (obj.getTD()) << " " << (obj.getTE()) << " " << obj.getP() << " " <<
				obj.getW();
		}
		/**
		* @brief Input stream operator for daily forecast.
		*
		* Gets values from the input stream and fills them into the Weather object.
		*
		* @param is  The input stream.
		* @param obj The Weather object.
		* @return std::istream& An input stream.
		*/
		friend std::istream& operator>>(std::istream& is, Weather& obj)
		{
			double temm, temd, teme, perc;
			std::tm d;
			int weather;
			is >> temm >> temd >> teme >> perc >> d.tm_mday >> d.tm_mon >> d.tm_year >> weather;
			if (is.good())
			{
				if (temm < -273 || temd < -273 || teme < -273 || perc > 5000 || perc < 0 || d.tm_mday < 1 || d.tm_mday > 31 ||
					d.tm_mon < 1 || d.tm_mon > 12 || d.tm_year < 0 || d.tm_year > 2500 || weather > 4 || weather < 1)
					is.setstate(std::ios::failbit);
				else {
					obj.setD(d);
					obj.setTM(temm);
					obj.setTD(temd);
					obj.setTE(teme);
					obj.setP(perc);
					Condition q = (Condition)weather;
					obj.setW(q);
				}
			}

			return is;
		}
		/**
		* @brief Less than operator.
		*
		* Compares two elements of the Weather class by date.
		*
		* @param const Weather& rhs  The second element of the Weather class.
		* 
		* @return true if the first object is newer by date.
		* @return false if the first object is not newer by date.
		*/
		bool operator < (const Weather& rhs) const {
			if (date.tm_year < rhs.date.tm_year) return true;
			else if (date.tm_mon < rhs.date.tm_mon && date.tm_year == rhs.date.tm_year) return true;
			else if (date.tm_mday < rhs.date.tm_mday && date.tm_mon == rhs.date.tm_mon && date.tm_year == rhs.date.tm_year) return true;
			else return false;
		}
		/**
		* @brief Equality operator.
		*
		* Compares two elements of the Weather class by date.
		*
		* @param const Weather& rhs  The second element of the Weather class.
		*
		* @return true if the second object is from the same date with the first.
		* @return false if the second object is not from the same date with the first.
		*/
		bool operator == (const Weather& rhs) const {
			if (date.tm_mday == rhs.date.tm_mday && date.tm_mon == rhs.date.tm_mon && date.tm_year == rhs.date.tm_year) return true;
			return false;
		}
		/**
		* @brief The addition assignment operator.
		*
		* Averages all numerical values ​​of two forecasts from one date.
		*
		* @param const Weather& rhs  The second element of the Weather class.
		*
		* @return Weather obj Received element of the class
		*/
		Weather &operator += (const Weather& rhs);

	};

	template<class T>
	T getNum(T min = std::numeric_limits<T>::lowest(), T max = std::numeric_limits<T>::max()) {
		T a;
		while (true) {
			std::cin >> a;
			if (std::cin.eof()) // обнаружен конец файла
				throw std::runtime_error("Failed to read number: EOF");
			else if (std::cin.bad()) // обнаружена невосстановимая ошибка входного потока
				throw std::runtime_error("Failed to read number: "); //+strerror(errno));
			// прочие ошибки (неправильный формат ввода) либо число не входит в заданный диапазон
			else if (std::cin.fail() || a < min || a > max) {
				std::cin.clear(); // очищаем флаги состояния потока
				// игнорируем все символы до конца строки
				std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
				std::cout << "You are wrong; repeat please!" << std::endl;
			}
			else // успешный ввод
				return a;
		}
	}
}
#endif //OOPPROG2_WEATHER_H
