/*
 * CGTestTarget.h
 *
 *  Created on: 2016/03/23
 *      Author: Kensuke
 */

#ifndef CGTESTTARGET_H_
#define CGTESTTARGET_H_

class CGTestTarget {
public:
	CGTestTarget();
	virtual ~CGTestTarget();
	int TestFunction(int n1, int n2);
};

#endif /* CGTESTTARGET_H_ */
