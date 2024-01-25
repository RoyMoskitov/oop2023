#ifndef OOPPROG3_FORECAST_H
#define OOPPROG3_FORECAST_H
#include <iostream>
#include "forecast.h"

/**
 * @file forecast2.h
 *
 * @brief This file consist of the Forecast class.
 */

namespace Prog2 {
	/**
	* @class Forecast
	*
	* @brief Array of multiple daily forecasts.
	*
	* The Forecast consists of array of daily forecasts, capacity and current size, 
	*/
	class Forecast {
	private:
		int ms = 1;
		int cs = 0;
		Weather* arr;
	public:
		/**
		* @brief Constructor with initial array of Weather objects.
		*
		* @param csize Size of the array you want to create.
		* @param arr Array of Weather objects.
		*/
		explicit Forecast(int csize, Weather* arr);
		/**
		* @brief Constructor with initial Weather object.
		* 
		* @param csize Size of the array you want to create.
		* @param ob Weather object.
		*/
		explicit Forecast(int csize, Weather ob);
		/**
		* @brief Default constructor for the forecast class.
		*
		* Constructs a Forecast object automatically.
		*/
		explicit Forecast();
		/**
		* @brief Copy constructor.
		* 
		* Constructs the same Forecats object with the first one.
		* 
		* @param old Old Forecast object to copy from.
		*/
		explicit Forecast(Forecast& old);
		/**
		* @brief Get the maximum size of the array.
		*
		* @return ms Maximum size.
		*/
		int getMS() const { return ms; };
		/**
		* @brief Get the current size of the array.
		*
		* @return cs Current size.
		*/
		int getCS() const { return cs; };
		/**
		* @brief Get the element of the array by index.
		*
		* @param i index of the element in the array.
		* 
		* @return Weather& An element of the array.
		*/
		Weather& getDF(int i);
		/**
		* @brief Delete the element from the array by its index.
		*
		* @param num index of the element in the array.
		*/
		void delW(int num);
		/**
		* @brief Find the coldest day from the defined period of time.
		*
		* @param st First day of the defined period of time.
		* @param fin Last day of the defined period of time.
		* 
		* @return Weather& An element of the array.
		*/
		Weather& Coldest(std::tm st, std::tm fin);
		/**
		* @brief Find the closest sunny date from the given date.
		*
		* @param now The current date.
		*
		* @return Weather& An element of the array.
		*/
		Weather& CloseSun(std::tm now);
		/**
		* @brief Changes the size of array.
		*
		* @param newsize The new size of the array.
		* @param oldsize The old size of the array.
		*
		* @return Weather* The new array of elements.
		*/
		Weather* change_size(int newsize, int oldsize);
		/**
		* @brief Adds the new element to the end of array.
		*
		* @param ob Added element of the array.
		*/
		void addDF(Weather ob);
		/**
		* @brief The addition assignment operator.
		*
		* Adds the new element to the end of array.
		*
		* @param ob Added element of the array.
		*
		* @return Forecast& Current forecast class.
		*/
		Forecast& operator += (Weather ob);
		/**
		* @brief square bracket syntax operator.
		*
		* @throw std::invalid_argument If the values are out of range.
		* 
		* @param idx index of the element in the array.
		* 
		* @return Weather& element of the array.
		*/
		Weather& operator [] (int idx) {
			if (cs <= idx || idx < 0) throw std::invalid_argument("invalid current size");
			return arr[idx]; 
		}
		/**
		* @brief Sorts the array of Weather classes by its date.
		*
		*/
		void sortF();
		/**
		* @brief Sorts an array of Weather classes for the selected time month.
		*
		* @param mon Month of the selected period.
		* @param year Year of the selected period.
		*
		* @return Forecast& New forecast class with the chosen month daily forecasts.
		*/
		Forecast& sortM(int mon, int year, Forecast& n);
		/**
		* @brief Delete all mistaken forecasts.
		*/
		void delM();
		/**
		* @brief Unificate all daily forecasts from the same date in the array in one.
		*/
		void Unite();
		/**
		* @brief Copy assignment operator.
		*
		* @param n The Forecast object from which to copy.
		* 
		* @return Forecast& New Forecast object.
		*/
		Forecast& operator = (Forecast& n);
		/**
		* @brief Destructor.
		*
		* Destroys the Forecast object.
		*/
		~Forecast();
		/**
		* @brief Moving constructor.
		*
		* @param n The Forecast object from which to move.
		*
		* @return Forecast& New Forecast object.
		*/
		Forecast(Forecast&& n) noexcept : ms(n.ms), cs(n.cs), arr(n.arr) {
			n.arr = nullptr;
		}
		/**
		* @brief Moving assignment operator.
		*
		* @param n The Forecast object from which to move.
		*
		* @return Forecast& New Forecast object.
		*/
		Forecast& operator = (Forecast&& n) noexcept {
			std::swap(cs, n.cs);
			std::swap(ms, n.ms);
			std::swap(arr, n.arr);
		}
		/**
		* @brief Output operator for forcast object.
		*
		* Writes the content of the forecast.
		*/
		void showFull();
		/**
		* @brief Output operator for forcast object.
		*
		* Writes the content of the forecast.
		*
		* @param os  The output stream.
		* @param obj The Weather object.
		* @return std::ostream& An output stream.
		*/
		friend std::ostream& operator<<(std::ostream& os, Forecast& obj);
		/**
		* @brief Input stream operator for forecast object.
		*
		* Gets values from the input stream and fills them into the Forecast object.
		*
		* @param is  The input stream.
		* @param obj The Forecast object.
		* @return std::istream& An input stream.
		*/
		friend std::istream& operator>>(std::istream& os, Forecast& obj);
	};
}
#endif //OOPPROG3_FORECAST_H
