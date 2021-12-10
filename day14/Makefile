#Makefile to run the programm
run: main func.o 
	g++ -Wall -o main.out main.o func.o
	./main.out
	rm -f *.out *.o 
main: main.cc header/func.hh 
	g++ -Wall -c -o main.o main.cc 
func.o: src/func.cc header/func.hh
	g++ -Wall -c -o func.o src/func.cc 

