using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
		private PowerupStateHandler m_PowerupHandler;
        private bool m_Jump;
        private bool m_Activate;
		private bool m_Red;
		private bool m_Blue;
		private bool m_Yellow;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			m_PowerupHandler = GetComponent<PowerupStateHandler> ();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (!m_Activate)
            {
                m_Activate = CrossPlatformInputManager.GetButtonDown("Activate");
            }
			if (CrossPlatformInputManager.GetButtonDown ("Red"))
			{
				m_PowerupHandler.ToggleColor (PowerupStateHandler.BottleColors.Red);
			}
			if (CrossPlatformInputManager.GetButtonDown ("Blue"))
			{
				m_PowerupHandler.ToggleColor (PowerupStateHandler.BottleColors.Blue);
			}
			if (CrossPlatformInputManager.GetButtonDown ("Yellow"))
			{
				m_PowerupHandler.ToggleColor (PowerupStateHandler.BottleColors.Yellow);
			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            if (m_Activate)
            {
                m_Character.activateButton();
            }
            m_Jump = false;
            m_Activate = false;
        }
    }
}
