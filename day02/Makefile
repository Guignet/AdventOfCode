#Makefile to run the programm
run: main func.o sub.o
	g++ -Wall -o main.out main.o func.o submarine.o
	./main.out
	rm -f *.out *.o 
main: main.cc header/func.hh header/submarine.hh 
	g++ -Wall -c -o main.o main.cc 
func.o: src/func.cc header/func.hh header/submarine.hh
	g++ -Wall -c -o func.o src/func.cc 

sub.o: src/submarine.cc header/submarine.hh
	g++ -Wall -c -o submarine.o src/submarine.cc 

