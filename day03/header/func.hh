#include <string>
#include <iostream>
#include <fstream>
#include <vector>
#include <cmath>
#include <unistd.h>

using namespace std;

int bin_to_int(string const bin);
int gammaXepsilon(string const nomFich);

int filter_pos(string const nomFich,int pos,int sup);
int oxygen_generator_rating(string const nomFich);
int CO2_scrubber_rating(string const nomFich);