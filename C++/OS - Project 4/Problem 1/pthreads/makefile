CPP=g++49
CPPLIBS=/opt/gcc49/lib
CFLAGS=-c -Wall -std=c++11
LDFLAGS=-L$(CPPLIBS) -lstdc++ -Wl,-rpath=$(CPPLIBS) -lpthread
SOURCES=printStuff.cpp main.cpp
HEADERS=printStuff.h
OBJECTS=$(SOURCES:.cpp=.o)
EXECUTABLE=printStuff

#====================================================

all: $(SOURCES) $(EXECUTABLE)

build: clean $(EXECUTABLE)

$(EXECUTABLE): $(OBJECTS)
	$(CPP) $(OBJECTS) $(LDFLAGS) -o $@

.cpp.o:
	$(CPP) $(CFLAGS) $< -o $@

run: $(EXECUTABLE)
	./$(EXECUTABLE)

clean:
	rm -f *.o
