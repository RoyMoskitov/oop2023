#ifndef OOPPROG1_PROG1_H
#define OOPPROG1_PROG1_H
#include <iostream>
#include <string>
#include <limits>
#include <cstring>

namespace Prog1 {
    struct element {
        int row = 0;
        int column = 0;
        int value = 0;
    };

    struct matrix {
        int size = 0;
        element* ptr = nullptr;
        int full = 0;
    };

    typedef int (*CallbackFunction)(int);

    int getNum();
    void make_v(const matrix& m, CallbackFunction callback);
    void erase(matrix& matrix);
    int callback1(int val);
    int callback2(int val);
    void output(const char* msg, const matrix& matrix);
    void add(matrix& m);
    matrix input();
}

#endif //OOPPROG1_PROG1_H
