package be.pxl.vegisens.aop;

import static be.pxl.vegisens.logging.LogColor.ANSI_GREEN;
import static be.pxl.vegisens.logging.LogColor.ANSI_RESET;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import be.pxl.vegisens.logging.JMSSender;

@Component
@Aspect
public class VegiSensAspect {

	@Autowired
	private JMSSender sender;
	
	@Around("execution(* *.getGrowableItems())")
	public Object longTimeMethod(ProceedingJoinPoint pjp) throws Throwable
	{
		long start = System.currentTimeMillis();

		sender.sendInformation(makeGreen("[Before Executing]"));

		Object returnValue = pjp.proceed();
		
		sender.sendInformation(makeGreen("[After Executing]"));
		
		long timeElapsed = System.currentTimeMillis() - start;
		
		sender.sendInformation(makeGreen("[EXECUTED]: Method execution time : " + timeElapsed + " miliseconds"));
		
		return returnValue;	
	}

	private String makeGreen(String str) {
		return ANSI_GREEN + str + ANSI_RESET;
	}
}