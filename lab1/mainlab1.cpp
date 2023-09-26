#include <iostream>
#include "prog1.h"
using namespace Prog1;
//static const char *msgs[] = { "1.Add". "2.


int main() {
    int choice;
    matrix matrix;
    try {
        matrix = input();
        output("Your matrix", matrix);
    }
    catch (const std::bad_alloc& ba) {
        std::cerr << "Not enough memory" << std::endl;
        erase(matrix);
        return 1;
    }
    catch (const std::exception& e) {
        std::cerr << e.what() << std::endl;
        erase(matrix);
        return 1;
    }
    while (true) {
        std::cout << "Choose function:" << std::endl;
        std::cout << "1. ADD" << std::endl;
        std::cout << "2. CALLBACK1 " << std::endl;
        std::cout << "3. CALLBACK2 " << std::endl;
        std::cout << "4. Print" << std::endl;
        std::cout << "0. Exit" << std::endl;
        std::cin >> choice;
        switch (choice) {
        case 1:
            try {
                add(matrix);
            }
            catch (...) {
                erase(matrix);
                return 1;
            }
            break;
        case 2:
            make_v(matrix, callback1);
            break;
        case 4:
            output("Your matrix", matrix);
            break;
        case 3:
            make_v(matrix, callback2);
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