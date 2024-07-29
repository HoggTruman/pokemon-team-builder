import React from "react";
import { userContext } from "../../context/userContext";
import { ACCOUNT_PAGE, TEAM_LIST_PAGE } from "../../pages/constants/pageNames";

function AccountButtons(props) {
    const { isLoggedIn, userName, logout } = userContext();


        
    // Render 
    // Buttons shown on account page
    if (props.page === ACCOUNT_PAGE) {
        return (
            <button
                onClick={() => props.setPage(TEAM_LIST_PAGE)}
            >
                Back To Teams
            </button>
        )
    }


    // buttons shown on other pages
    const loggedOutButtons = (
            <button
                onClick={() => props.setPage(ACCOUNT_PAGE)}
            >
                Register / Log In
            </button>
    );

    const loggedInButtons = (
        <>
            <p>{userName}</p>
            <button
                onClick={logout}
            >
                Log Out
            </button>
        </>
    );

    return (
        <div id="accountButtons">
            {
                isLoggedIn()? loggedInButtons: loggedOutButtons
            }
        </div>
    )

}

export default AccountButtons;