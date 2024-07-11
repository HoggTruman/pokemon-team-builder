import React from "react";

class AccountButtons extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        const SIGNEDIN = false;

        const signedOutButtons = (
            <>
                <button>Register</button>
                <button>Log In</button>
            </>
        );

        const signedInButtons = (
            <>
                <button>Log Out</button>
            </>
        );

        return (
            <div id="accountButtons">
                {
                    SIGNEDIN? signedInButtons: signedOutButtons
                }
            </div>
        )
    }
}

export default AccountButtons;