package be.pxl.vegisens.logging;

import javax.jms.*;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;

@Component
public class JMSReceiver {

	private final String JMS_QUEUE = "VegiSensQueue";
	private final String INFO_PREFIX = "[INFO]: ";
	private final String ERROR_PREFIX = "[ERROR]: ";
	
	@JmsListener(destination=JMS_QUEUE)
	public void onInformationReceived(Message message)
	{
		try 
		{
			if(message instanceof TextMessage)
			{
				String text = ((TextMessage)message).getText();
				System.out.println(INFO_PREFIX + text);
			}
		}
		catch (JMSException e)
		{
			System.out.println(ERROR_PREFIX + "something went wrong in receiving the message.");
		}
	}
}
