package main.java.be.pxl.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class GrowableItemService implements IGrowableITemService {

	@Autowired
	private GrowableITemR mirrorRepository;
	
	@Override
	public void storeCall(Call call) 
	{
		mirrorRepository.save(call);		
	}
}


