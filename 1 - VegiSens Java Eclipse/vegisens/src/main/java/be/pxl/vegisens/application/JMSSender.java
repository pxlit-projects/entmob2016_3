package be.pxl.vegisens.application;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

@Component
public class JMSSender {

	private final String JMS_QUEUE = "VegiSensQueue";
	
	@Autowired
	private JmsTemplate jmsTemplate;
	
	public void sendInformation(String information)
	{
		jmsTemplate.send(JMS_QUEUE, s -> s.createTextMessage(information));
	}
}