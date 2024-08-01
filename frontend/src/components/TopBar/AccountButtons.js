import React from "react";
import { userContext } from "../../context/userContext";
import { ACCOUNT_PAGE, TEAM_EDIT_PAGE, TEAM_LIST_PAGE } from "../../pages/constants/pageNames";

function AccountButtons(props) {
    const { isLoggedIn, userName, logout } = userContext();

    function handleClickLogout() {
        if (props.page === TEAM_EDIT_PAGE || props.page === ACCOUNT_PAGE) {
            return;
        }

        logout();
        props.setTeams(teams => {
            return teams.filter(team => team.id < 0);
        })
    }

    function handleClickLoginRegister() {
        if (props.page === TEAM_EDIT_PAGE || props.page === ACCOUNT_PAGE) {
            return;
        }
        props.setPage(ACCOUNT_PAGE);
    }


        
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
                onClick={handleClickLoginRegister}
                disabled={props.page === TEAM_EDIT_PAGE}
            >
                Register / Log In
            </button>
    );

    const loggedInButtons = (
        <>
            <p>{userName}</p>
            <button
                onClick={handleClickLogout}
                disabled={props.page === TEAM_EDIT_PAGE}
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