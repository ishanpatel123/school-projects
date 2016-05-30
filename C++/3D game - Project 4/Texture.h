#pragma once
#ifndef TEXTURE
#define TEXTURE

class Texture
{
protected:
	unsigned char* data;
	unsigned int width, height;

public:
	Texture();

	virtual ~Texture();

	void set(unsigned char* data, unsigned int width, unsigned int height);

	unsigned char* getData() { return this->data; }

	unsigned int getHeight() { return this->height; }

	unsigned int getWidth() { return this->width; }

	virtual void create() {};

	virtual void select() {};

};

#endif

