namespace EM
{
	interface IToolbarInterface
	{
		void OnAdd();
		void OnDelete();
		void OnCancel();
		void OnNext();
		void OnPrevious();
		void OnRefresh();
		void OnUpdate();
		void OnFind();

		bool OnUpdateAdd();
		bool OnUpdateDelete();
		bool OnUpdateCancel();
		bool OnUpdateNext();
		bool OnUpdatePrevious();
		bool OnUpdateRefresh();
		bool OnUpdateUpdate();
		bool OnUpdateFind();
		
		bool CheckForDirty();
	}
}