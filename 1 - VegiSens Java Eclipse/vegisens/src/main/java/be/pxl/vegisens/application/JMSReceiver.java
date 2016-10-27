package be.pxl.vegisens.application;

import javax.jms.*;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;

@Component
public class JMSReceiver {

	private final String JMS_QUEUE = "VegiSensQueue";
	private final String PREFIX = "[INFO]: ";
	
	@JmsListener(destination=JMS_QUEUE)
	public void onInformationReceived(Message message)
	{
		try 
		{
			if(message instanceof TextMessage)
			{
				String text = ((TextMessage)message).getText();
				System.out.println(PREFIX + text);
			}
		}
		catch (JMSException e)
		{
			System.out.println("[ERROR]: something went wrong in receiving the message");
		}
	}
}
