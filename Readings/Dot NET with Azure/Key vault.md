# Configure connection string 
1. Create a Key Vault
2. Create a Secret in Key Vault
	- name
	- value
3. Create web app Identity
	- Identity
	- Status: On
	- System assigned
	- Object (principal) ID: copy this
4. Add Access Policy
	- in key vault -> access policies
	- add access policy: Get, List
	- to Principal
5. Add Key Vault secret to appsettings
