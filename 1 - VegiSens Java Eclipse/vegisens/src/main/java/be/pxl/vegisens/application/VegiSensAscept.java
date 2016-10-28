package be.pxl.vegisens.application;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
@Aspect
public class VegiSensAscept {

	@Autowired
	private JMSSender sender;
	
	@Around("execution(* *.getGrowableItems())")
	public Object longTimeMethod(ProceedingJoinPoint pjp) throws Throwable
	{
		long start = System.currentTimeMillis();
		
		sender.sendInformation("[Before Executing]");
		
		Object returnValue = pjp.proceed();
		
		sender.sendInformation("[After Executing]");
		
		long timeElapsed = System.currentTimeMillis() - start;
		
		sender.sendInformation("[EXECUTED]: Method execution time : " + timeElapsed + " miliseconds");
		
		return returnValue;	
	}
}
