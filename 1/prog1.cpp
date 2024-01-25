#include <iostream>
#include "prog1.h"
#include <algorithm>

namespace Prog1 {

    int getNum() {
        constexpr int min = std::numeric_limits<int>::min();
        constexpr int max = std::numeric_limits<int>::max();
        int a;
        while (true) {
            std::cin >> a;
            if (std::cin.eof()) // обнаружен конец файла
                throw std::runtime_error("Failed to read number: EOF");
            else if (std::cin.bad()) // обнаружена невосстановимая ошибка входного потока
                throw std::runtime_error("Failed to read number: "); //+ strerror(errno));
            else if (std::cin.fail()) { // прочие ошибки (неправильный формат ввода)
                std::cin.clear(); // очищаем флаги состояния потока
                // игнорируем все символы до конца строки
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "You are wrong; repeat please!" << std::endl;
            }
            else if (a >= min && a <= max) // если число входит в заданный диапазон
                return a;
        }
    }

    void erase(matrix& matrix) {
        if (matrix.ptr != nullptr) {
            delete[] matrix.ptr;
            matrix.ptr = nullptr;
        }
        matrix.size = 0;
    }

    bool customer_sorter(element x, element  y) {
        if (x.row == y.row)
            return x.column < y.column;
        return x.row < y.row;
    }

    matrix input() {
        // выделение памяти для матрицы
        matrix m;
        try {
            std::cout << "Enter number of elements: --> ";
            m.size = getNum();
            //while(matrix.full <= )
            //выделяем память под массив структур - строк матрицы
            m.ptr = new element[m.size];
            int h = 0;
            for (int i = 0; i < m.size; i++) {
                std::cout << "Enter items for matrix and its position:" << std::endl;
                m.ptr[i].value = getNum();
                m.ptr[i].row = getNum();
                m.ptr[i].column = getNum();
                // for (int j=0; matrix.ptr[j].row < matrix.ptr[i].row; ++j) h = j+1;
                // if (matrix.full != h) {
                //     //std::cout << "Error";
                //     for (int k=h; matrix.ptr[k].column < matrix.ptr[i].column; ++k) h=k+1;
                //     if (matrix.full != h) {
                //         int val = matrix.ptr[i].value, row = matrix.ptr[i].row, col = matrix.ptr[i].column;
                //         for (int k=matrix.full; k>h; --k) matrix.ptr[k] = matrix.ptr[k-1];
                //         matrix.ptr[h].value = val;
                //         matrix.ptr[h].row = row;
                //         matrix.ptr[h].column = col;
                //     }
                // }

                m.full++;
            }
            //for (int i = 0; i < m.size; ++i) std::cout << m.ptr[i].value << "  ";
            //std::cout << std::endl;
            std::sort(m.ptr, m.ptr + m.full, customer_sorter);

            //std::qsort(matrix.ptr, matrix.full, sizeof(element), customer_sorter);
            //for (int i=0; i<m.size; ++i) std::cout << m.ptr[i].value << "  ";
            //std::cout << std::endl;
        }
        catch (...) { // в случае любого исключения
            erase(m); // очищаем уже выделенную память
            throw; // перекидываем то же исключение дальше
        }
        return m;
    }

    void output(const char* msg, const matrix& matrix) {
        std::cout << msg << ":\n";
        int start = 1, row = 1;
        for (int i = 0; i < matrix.full; ++i) {
            while (matrix.ptr[i].row > row) {
                row++;
                start = 1;
                std::cout << std::endl;
            }
            int finish = matrix.ptr[i].column;
            while (finish - start > 0) {
                std::cout << "         ";
                start++;
            }
            start = finish;
            //std::cout << left << setw(9) << matrix.ptr[i].value;
            std::cout << matrix.ptr[i].value;
        }
        std::cout << std::endl;
    }

    void make_v(const matrix& m, CallbackFunction callback) {
        int* vec = new int[m.ptr[m.full - 1].row];
        for (int i = 0; i < m.ptr[m.full - 1].row; ++i) vec[i] = 0;
        int row = 0;
        for (int i = 0; i < m.full; ++i) {
            while (m.ptr[i].row > row + 1) {
                row++;
            }
            //int num;
            int val = m.ptr[i].value;
            if (callback(val) == 1) vec[row] += val;
        }
        std::cout << "Result: " << std::endl;
        for (int i = 0; i < m.ptr[m.full - 1].row; ++i) std::cout << vec[i] << "  ";
        delete[]vec;
        std::cout << std::endl;
    }

    int callback1(int val) {
        if (val == 0) return 0;
        val = std::abs(val);
        while (val > 0) {
            if (val % 10 == 0) return 0;
            val /= 10;
        }
        return 1;
    }

    int callback2(int val) {
        val = std::abs(val);
        if (val % 2 == 0) return 1;
        return 0;
    }


    element *change_size(matrix m, int newsize, int oldsize) {
        element *newbuf = new element[newsize];
        std::copy_n(m.ptr, oldsize, newbuf);
        delete[] m.ptr;
        return newbuf;
    }

    int exist(const matrix& m, int row, int col, int old) {
        for (int i = old; i < m.full; ++i) {
            if ((m.ptr->column == row && m.ptr->column == col) || row<=0 || col<=0) {
                std::cout << "You are wrong, repeat please:" << std::endl;
                return 1;
            }
        }
        return 0;
    }

    void add(matrix& m) {
        std::cout << "Enter number of items you want to add:" << std::endl;
        int size = getNum();
        int old = m.size;
        while (size + m.full > m.size) {
            m.size *= 2;
        }
        m.full += size;
        try {
            m.ptr = change_size(m, m.size, old);
        }
        catch (...) { // в случае любого исключения
            erase(m); // очищаем уже выделенную память
            throw; // перекидываем то же исключение дальше
        }
        std::cout << "Enter items for matrix and its position:" << std::endl;
        for (int i = old; i < m.full; ++i) {
            while (1) {
                m.ptr[i].value = getNum();
                m.ptr[i].row = getNum();
                m.ptr[i].column = getNum();
                if (exist(m, m.ptr[i].row, m.ptr[i].column, old) == 0) break;
            }
        }
        //std::qsort(m.ptr, m.full, sizeof(element), customer_sorter);
        //.std::sort();
        std::sort(m.ptr, m.ptr + m.full, customer_sorter);
        //std::qsort(m.ptr.begin(), m.ptr.end(), &customer_sorter);
    }
}