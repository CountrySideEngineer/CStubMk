#ifndef TESTFILENAME2_STUB_H_
#define TESTFILENAME2_STUB_H_
#endif

#ifdef __cplusplus
extern "C" {
#endif /* __cplusplus */

/*---- TestFuncName stub start ----*/
extern int TestFuncName_stub_called_count;
extern int TestFuncName_stub_ret_val[];
extern TestArgType TestFuncName_stub_arg_1[];
extern TestArgType2* TestFuncName_stub_arg_2[];
extern TestArgType3* TestFuncName_stub_arg_3[];
#define	GET_TESTFUNCNAME_STUB_CALLED_COUNT()\
	(TestFuncName_stub_called_count)
#define	SET_TESTFUNCNAME_STUB_CALLED_COUNT(value)\
	(TestFuncName_stub_called_count = value)
#define	GET_TESTFUNCNAME_STUB_ARG_1(idx)\
	(TestFuncName_stub_arg_1[idx])
#define	SET_TESTFUNCNAME_STUB_ARG_1(idx, value)\
	(TestFuncName_stub_arg_1[idx] = value)
#define	GET_TESTFUNCNAME_STUB_ARG_2(idx)\
	(TestFuncName_stub_arg_2[idx])
#define	SET_TESTFUNCNAME_STUB_ARG_2(idx, value)\
	(TestFuncName_stub_arg_2[idx] = value)
#define	GET_TESTFUNCNAME_STUB_ARG_3(idx)\
	(TestFuncName_stub_arg_3[idx])
#define	SET_TESTFUNCNAME_STUB_ARG_3(idx, value)\
	(TestFuncName_stub_arg_3[idx] = value)
#define	GET_TESTFUNCNAME_STUB_RET_VAL(idx)\
	(TestFuncName_stub_ret_val[idx])
#define	SET_TESTFUNCNAME_STUB_RET_VAL(idx, value)\
	(TestFuncName_stub_ret_val[idx] = value)
#ifdef __cplusplus
}
#endif /* __cplusplus */
#endif /* TESTFILENAME2_STUB_H_ */
