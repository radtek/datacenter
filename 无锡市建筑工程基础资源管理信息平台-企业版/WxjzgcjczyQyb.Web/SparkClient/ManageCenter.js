
	/*
	SetChecboxProperty��������argForm�е�����id�����Ӵ�argSubstrOfCheckboxID������Ϊcheckbox��html�ؼ�
	��checked������Ϊ��argSourceCheckbox����ؼ���checked����һ��
	*/
	function SetCheckboxProperty(argForm,argSourceCheckbox,argSubstrOfCheckboxID)
	{
		for (i=0;i<argForm.length;i++)
		{
			var tempobj=argForm.elements[i]
			if ((tempobj.type.toLowerCase()=="checkbox") && (tempobj.id.toLowerCase().lastIndexOf(argSubstrOfCheckboxID.toLowerCase()) > 0))
				tempobj.checked = argSourceCheckbox.checked;
		}
	}
	
	/*
	AreAllChecked�������ж�argForm�е�����id�����Ӵ�argSubstrOfCheckboxID������Ϊcheckbox��html�ؼ�
	��checked�����Ƿ�������
	*/
	function AreAllChecked(argForm,argSubstrOfCheckboxID)
	{
		var allChecked = true;
		for (i=0;i<argForm.length;i++)
		{
			var tempobj=argForm.elements[i]
			if ((tempobj.type.toLowerCase()=="checkbox") && (tempobj.id.toLowerCase().lastIndexOf(argSubstrOfCheckboxID.toLowerCase()) > 0))
				if (tempobj.checked == false)
				{
					allChecked = false;
					break;
				}
		}
		return(allChecked);
	}