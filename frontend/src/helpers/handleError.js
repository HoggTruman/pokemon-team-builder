import axios from "axios";
import { toast } from "react-toastify"

function handleError(error) {
    if (axios.isAxiosError(error)) {
        const err = error.response;

        if (Array.isArray(err?.data.errors)) {
            for (let e of err.data.errors) {
                toast.warning(e.description);
            }
        }
        else if (typeof err?.data.errors === "object") {
            for (let e in err.data.errors) {
                toast.warning(err.data.errors[e][0]);
            }
        }
        else if (err?.data) {
            toast.warning(err.data);
        }
        else if (err?.status == 401) {
            toast.warning("Not logged in")
        }
    }
}

export default handleError;