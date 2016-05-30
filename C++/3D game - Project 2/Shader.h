#pragma once
#ifndef SHADER
#define SHADER

class Logger;

class Shader
{
protected:
	Logger* logger;

public:
	Shader();
	virtual ~Shader();

	virtual bool create() = 0;
	virtual void renderObjects() = 0;

	void setLogger(Logger* logger) { this->logger = logger; }
};

#endif

