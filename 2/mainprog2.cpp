#include <iostream>
#include "forecast.h"
#include "forecast2.h"
#include <string>
#include <time.h>
#include <format>
#include <ctime>
#include <vector>

using namespace Prog2;

Weather cc(double t1, double t2, double t3, double p1, std::tm d) {
    Weather o1(d, t1, t2, t3, p1);
    return o1;
}

int main() {
    std::srand(55);
    std::tm d;
    std::vector<std::string> menu =
    {
        "1. SetTM",
        "2. SetTD ",
        "3. SetTE ",
        "4. Set perception",
        "5. Set weather condition",
        "6. Set date",
        "7. Get average temperature per day",
        "8. Check for mistake",
        "9. Compare 2 forecasts",
        "10. Show forecast",
        "11. Add element",
        "12. Make average day forecast",
        "13. Sort day forecasts",
        "13. Delete one day forecast", 
        "14. Find closest sunny day",
        "15. Find the coldest day",
        "16. Delete all mistaken forecasts",
        "17. Unite all forecasts from the same day",
        "18. Show full forecast",
        "19. Enter full forecast",
        "20. Sort your forecasts",
        "21. Get a sorted forecast for chosen month",
        "22. Show full forecast w operator",
        "0. Exit"
    };
	Condition r = sunny;
    int size = 10, i=0, j=0;
	int choice, check;
    Forecast ob1, ob2;
    Weather oo, o2;
    double t;
    while (true) {
        std::cout << "Choose function:" << std::endl;
        for (int i = 0; i < 22; ++i) std::cout << menu[i] << std::endl;
        choice = getNum<int>(0, 22);
        switch (choice) {
        case 1:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                //std::cin >> i;
                i = getNum<int>(0);
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    std::cout << "Enter value: ";
                    t = getNum<double>(-273, 500);
                    ob1.getDF(i).setTM(t);
                    break;
                }
            }
            break;
        case 2:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    std::cout << "Enter value: ";
                    t = getNum<double>(-273, 500);
                    ob1.getDF(i).setTD(t);
                    break;
                }
            }
            break;
        case 3:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    std::cout << "Enter value: ";
                    t = getNum<double>(-273, 500);
                    ob1.getDF(i).setTE(t);
                    break;
                }
            }
            break;
        case 4:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    std::cout << "Enter value: ";
                    t = getNum<double>(-273, 500);
                    ob1.getDF(i).setP(t);
                    break;
                }
            }
            break;
        case 5:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    std::cout << "Enter value: ";
                    check = getNum<int>(1, 4);
                    ob1.getDF(i).setTE(t);
                    r = (Condition)check;
                    ob1[i - 1].setW(r);
                    break;
                }
            }
            break;
        case 6:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    std::cout << "Enter values: ";
                    d.tm_mday = getNum<int>(1, 31);
                    d.tm_mon = getNum<int>(1, 12);
                    d.tm_year = getNum<int>(0, 2024);
                    ob1[i - 1].setD(d);
                    break;
                }
            }
            break;
        case 7:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    t = ob1[i - 1].midT();
                    std::cout << "Average temperature is " << t << std::endl;
                    break;
                }
            }
            break;
        case 8:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                //std::cin >> i;
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    if (ob1.getDF(i).mistake() == 1) std::cout << "Forecast is incorrect" << std::endl;
                    else std::cout << "Forecast is correct" << std::endl;
                    break;
                }
            }
            break;
        case 9:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's indices: ";
                i = getNum<int>(0);
                j = getNum<int>(0);
                //std::cin >> i >> j;
                if (ob1.getCS() < i || ob1.getCS() < j || i == j) std::cout << "Wrong index" << std::endl;
                else {
                    if (ob1[i-1] == ob1[j-1]) std::cout << "These are forecasts from the one date" << std::endl;
                    else if (ob1[i - 1] < ob1[j - 1]) std::cout << "First forecast is newer" << std::endl;
                    else std::cout << "Second forecast is newer" << std::endl;
                    break;
                }
            }
            break;
        case 10:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                //std::cin >> i;   
                i = getNum<int>(0);
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    ob1.getDF(i).show();
                    break;
                }
            }
            break;
        case 11:
            std::cout << "Choose the constructor (1 - full construct, 2 - construct without weather condition, 3 - standart): ";
            //std::cin >> i;
            i = getNum<int>(1, 3);
            switch (i) {
            case (1):
                std::cin >> oo;
                //oo.operator>>(std::cin);
                ob1 += (oo);
                break;
            case(3):
                ob1 += (o2);
                break;
            case(2):
                double t1, t2, t3, p1;
                std::cout << "Enter temperatures (morning day evening), Perception, date: ";
                t1 = getNum<double>(-273, 500);
                t2 = getNum<double>(-273, 500);
                t3 = getNum<double>(-273, 500);
                p1 = getNum<double>(0, 5000);
                d.tm_mday = getNum<int>(1, 31);
                d.tm_mon = getNum<int>(1, 12);
                d.tm_year = getNum<int>(1, 3000);
                //std::cin >> t1 >> t2 >> t3 >> p1 >> d.tm_mday >> d.tm_mon >> d.tm_year;
                oo = cc(t1, t2, t3, p1, d);
                ob1 += (oo);
            }
            break;
        case 12:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's indices: ";
                i = getNum<int>(0);
                j = getNum<int>(0);
                if (ob1.getCS() < i || ob1.getCS() < j || i == j) std::cout << "Wrong index" << std::endl;
                else {
                    ob1[i-1] += ob1[j-1];
                    break;
                }
            }
            break;
        case 13:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter element's index: ";
                i = getNum<int>(0);
                if (ob1.getCS() < i) std::cout << "Wrong index" << std::endl;
                else {
                    ob1.delW(i-1);
                    break;
                }
            }
            break;
        case 14:
            if (ob1.getCS() == 0) break;
            std::cout << "Enter today's date: ";
            d.tm_mday = getNum<int>(1, 31);
            d.tm_mon = getNum<int>(1, 12);
            d.tm_year = getNum<int>(1, 3000);
            oo = ob1.CloseSun(d);
            std::cout << "The closest sunny day" << std::endl;
            //oo.operator<<(std::cout);
            oo.show();
            break;
        case 15:
            if (ob1.getCS() == 0) break;
            std::tm d1;
            std::cout << "Enter two dates (upper and lower) : ";
            d.tm_mday = getNum<int>(1, 31);
            d.tm_mon = getNum<int>(1, 12);
            d.tm_year = getNum<int>(1, 3000);
            d1.tm_mday = getNum<int>(1, 31);
            d1.tm_mon = getNum<int>(1, 12);
            d1.tm_year = getNum<int>(1, 3000);
            oo = ob1.Coldest(d, d1);
            std::cout << "The coldest day" << std::endl;
            //oo.operator<<(std::cout);
            oo.show();
            break;
        case 16:
            if (ob1.getCS() == 0) break;
            ob1.delM();
            break;
        case 17:
            if (ob1.getCS() == 0) break;
            ob1.Unite();
            break;
        case 18:
            if (ob1.getCS() == 0) {
                std::cout << "Your forecast is empty!" << std::endl;
            }
            else {
                ob1.showFull();
            }
            break;
        case 19:
            std::cout << "Enter the number of elements, you want to enter " << std::endl;
            std::cout <<  "And then temperatures(morning day evening), Perception, date and weather for each : ";
            std::cin >> ob1;
            break;
        case 20:
            if (ob1.getCS() == 0) break;
            ob1.sortF();
            break;
        case 21:
            if (ob1.getCS() == 0) break;
            while (1) {
                std::cout << "Enter month and year of the forecast : ";
                //std::cin >> d.tm_mon >> d.tm_year;
                d.tm_mon = getNum<int>(1, 12);
                d.tm_year = getNum<int>(1, 3000);
                ob1.sortM(d.tm_mon, d.tm_year, ob2);
                //ob2.operator<<(std::cout);
                break;
            }
            break;
        case 22: 
            if (ob1.getCS() == 0) {
                std::cout << "Your forecast is empty!" << std::endl;
            }
            else {
                //ob1.operator<<(std::cout);
                std::cout << ob1;
                std::cout << std::endl;
            }
            break;
        case 0:
            std::cout << "Exit from prog." << std::endl;
            return 0;
        default:
            if (std::cin.eof()) {
                std::cout << "Exit from prog." << std::endl;
                return 0;
            }
            std::cout << "Wrong option, please, try again." << std::endl;
            break;
        }
    }
	return 0;
}
