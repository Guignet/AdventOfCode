#Makefile to run the programm
run: main func.o grille.o 
	g++ -Wall -o main.out main.o func.o grille.o
	./main.out
	rm -f *.out *.o 
main: main.cc header/func.hh header/grille.hh
	g++ -Wall -c -o main.o main.cc 
func.o: src/func.cc header/func.hh header/grille.hh
	g++ -Wall -c -o func.o src/func.cc 

grille.o: src/grille.cc header/grille.hh
	g++ -Wall -c -o grille.o src/grille.cc