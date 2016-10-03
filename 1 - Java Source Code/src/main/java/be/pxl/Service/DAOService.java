package be.pxl.Service;

import be.pxl.Bean.Growable_ItemBean;
import be.pxl.DAO.IServiceDAO;
import be.pxl.DAO.VegiSensDAO;

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
