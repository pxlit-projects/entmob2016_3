package be.pxl.services;

import be.pxl.models.Growable_ItemBean;
import be.pxl.DAO.IServiceDAO;

public class DAOService implements IServiceDAO {

	IServiceDAO daoService;
	
	public DAOService(IServiceDAO daoService)
	{
		this.daoService = daoService;
	}
	public Growable_ItemBean getGrowableItemBeanData(Growable_ItemBean growableItem) 
	{
		return daoService.getGrowableItemBeanData(growableItem);
			
	}
}
